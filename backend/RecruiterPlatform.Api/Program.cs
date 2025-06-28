using Microsoft.OpenApi.Models;
using Core.Entities;
using Application.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Recruiter Platform API",
        Version = "v1",
        Description = "A modern internal recruiter platform API following Clean Architecture principles",
        Contact = new OpenApiContact
        {
            Name = "Development Team",
            Email = "dev@recruiterplatform.com"
        }
    });
    
    // Add XML comments support
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Recruiter Platform API v1");
        c.RoutePrefix = "api-docs"; // Custom route prefix
        c.DocumentTitle = "Recruiter Platform API Documentation";
        c.DefaultModelsExpandDepth(2);
        c.DefaultModelExpandDepth(2);
    });
}

app.UseHttpsRedirection();

// In-memory storage for demo purposes (replace with proper repository in production)
var jobs = new List<Job>();

// API Endpoints
app.MapGet("/", () => "Recruiter Platform API is running!")
    .WithName("Root")
    .WithOpenApi(operation =>
    {
        operation.Summary = "API root endpoint";
        operation.Description = "Returns a simple message indicating the API is running";
        return operation;
    });

app.MapGet("/health", () => new { Status = "Healthy", Timestamp = DateTime.UtcNow })
    .WithName("HealthCheck")
    .WithOpenApi(operation =>
    {
        operation.Summary = "Health check endpoint";
        operation.Description = "Returns the health status of the API";
        return operation;
    });

app.MapGet("/api/version", () => new { Version = "1.0.0", Environment = app.Environment.EnvironmentName })
    .WithName("GetVersion")
    .WithOpenApi(operation =>
    {
        operation.Summary = "Get API version";
        operation.Description = "Returns the current version and environment of the API";
        return operation;
    });

// Job endpoints
app.MapGet("/api/jobs", () =>
{
    var jobDtos = jobs.Select(job => new JobDto
    {
        Id = job.Id,
        Title = job.Title,
        Description = job.Description,
        Company = job.Company,
        Location = job.Location,
        PublishedAt = job.PublishedAt,
        Status = job.Status.ToString(),
        SalaryRange = job.SalaryRange
    }).ToList();
    
    return Results.Ok(jobDtos);
})
.WithName("GetJobs")
.WithOpenApi(operation =>
{
    operation.Summary = "Get all jobs";
    operation.Description = "Retrieves a list of all job postings";
    return operation;
});

app.MapGet("/api/jobs/{id:guid}", (Guid id) =>
{
    var job = jobs.FirstOrDefault(j => j.Id == id);
    if (job == null)
        return Results.NotFound(new { Message = "Job not found" });
    
    var jobDto = new JobDto
    {
        Id = job.Id,
        Title = job.Title,
        Description = job.Description,
        Company = job.Company,
        Location = job.Location,
        PublishedAt = job.PublishedAt,
        Status = job.Status.ToString(),
        SalaryRange = job.SalaryRange
    };
    
    return Results.Ok(jobDto);
})
.WithName("GetJobById")
.WithOpenApi(operation =>
{
    operation.Summary = "Get job by ID";
    operation.Description = "Retrieves a specific job posting by its unique identifier";
    return operation;
});

app.MapPost("/api/jobs", (CreateJobRequest request) =>
{
    try
    {
        var job = Job.Create(
            request.Title,
            request.Description,
            request.Company,
            request.Location,
            request.SalaryRange
        );
        
        jobs.Add(job);
        
        var jobDto = new JobDto
        {
            Id = job.Id,
            Title = job.Title,
            Description = job.Description,
            Company = job.Company,
            Location = job.Location,
            PublishedAt = job.PublishedAt,
            Status = job.Status.ToString(),
            SalaryRange = job.SalaryRange
        };
        
        return Results.Created($"/api/jobs/{job.Id}", jobDto);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { Message = ex.Message });
    }
})
.WithName("CreateJob")
.WithOpenApi(operation =>
{
    operation.Summary = "Create a new job";
    operation.Description = "Creates a new job posting with the provided information";
    return operation;
});

app.MapPut("/api/jobs/{id:guid}/status", (Guid id, JobStatus newStatus) =>
{
    var job = jobs.FirstOrDefault(j => j.Id == id);
    if (job == null)
        return Results.NotFound(new { Message = "Job not found" });
    
    job.UpdateStatus(newStatus);
    
    var jobDto = new JobDto
    {
        Id = job.Id,
        Title = job.Title,
        Description = job.Description,
        Company = job.Company,
        Location = job.Location,
        PublishedAt = job.PublishedAt,
        Status = job.Status.ToString(),
        SalaryRange = job.SalaryRange
    };
    
    return Results.Ok(jobDto);
})
.WithName("UpdateJobStatus")
.WithOpenApi(operation =>
{
    operation.Summary = "Update job status";
    operation.Description = "Updates the status of an existing job posting";
    return operation;
});

app.Run();
