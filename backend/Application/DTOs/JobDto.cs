namespace Application.DTOs;

/// <summary>
/// Data transfer object for job information
/// </summary>
public class JobDto
{
    /// <summary>
    /// Unique identifier for the job
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Title of the job position
    /// </summary>
    public string Title { get; set; } = string.Empty;
    
    /// <summary>
    /// Description of the job requirements and responsibilities
    /// </summary>
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// Company or organization offering the position
    /// </summary>
    public string Company { get; set; } = string.Empty;
    
    /// <summary>
    /// Location where the job is based
    /// </summary>
    public string Location { get; set; } = string.Empty;
    
    /// <summary>
    /// Date when the job was published
    /// </summary>
    public DateTimeOffset PublishedAt { get; set; }
    
    /// <summary>
    /// Current status of the job posting
    /// </summary>
    public string Status { get; set; } = string.Empty;
    
    /// <summary>
    /// Salary range for the position
    /// </summary>
    public string? SalaryRange { get; set; }
}

/// <summary>
/// Request DTO for creating a new job
/// </summary>
public class CreateJobRequest
{
    /// <summary>
    /// Title of the job position
    /// </summary>
    public string Title { get; set; } = string.Empty;
    
    /// <summary>
    /// Description of the job requirements and responsibilities
    /// </summary>
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// Company or organization offering the position
    /// </summary>
    public string Company { get; set; } = string.Empty;
    
    /// <summary>
    /// Location where the job is based
    /// </summary>
    public string Location { get; set; } = string.Empty;
    
    /// <summary>
    /// Optional salary range for the position
    /// </summary>
    public string? SalaryRange { get; set; }
} 