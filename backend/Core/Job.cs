namespace Core.Entities;

/// <summary>
/// Represents a job posting in the recruiter platform
/// </summary>
public class Job
{
    /// <summary>
    /// Unique identifier for the job
    /// </summary>
    public Guid Id { get; private set; }
    
    /// <summary>
    /// Title of the job position
    /// </summary>
    public string Title { get; private set; }
    
    /// <summary>
    /// Description of the job requirements and responsibilities
    /// </summary>
    public string Description { get; private set; }
    
    /// <summary>
    /// Company or organization offering the position
    /// </summary>
    public string Company { get; private set; }
    
    /// <summary>
    /// Location where the job is based
    /// </summary>
    public string Location { get; private set; }
    
    /// <summary>
    /// Date when the job was published
    /// </summary>
    public DateTimeOffset PublishedAt { get; private set; }
    
    /// <summary>
    /// Current status of the job posting
    /// </summary>
    public JobStatus Status { get; private set; }
    
    /// <summary>
    /// Salary range for the position
    /// </summary>
    public string? SalaryRange { get; private set; }

    private Job() { } // For EF Core

    /// <summary>
    /// Creates a new job posting
    /// </summary>
    /// <param name="title">Job title</param>
    /// <param name="description">Job description</param>
    /// <param name="company">Company name</param>
    /// <param name="location">Job location</param>
    /// <param name="salaryRange">Optional salary range</param>
    /// <returns>A new Job instance</returns>
    public static Job Create(string title, string description, string company, string location, string? salaryRange = null)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Job title cannot be empty", nameof(title));
        
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Job description cannot be empty", nameof(description));
        
        if (string.IsNullOrWhiteSpace(company))
            throw new ArgumentException("Company name cannot be empty", nameof(company));
        
        if (string.IsNullOrWhiteSpace(location))
            throw new ArgumentException("Job location cannot be empty", nameof(location));

        return new Job
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description,
            Company = company,
            Location = location,
            SalaryRange = salaryRange,
            PublishedAt = DateTimeOffset.UtcNow,
            Status = JobStatus.Open
        };
    }

    /// <summary>
    /// Updates the job status
    /// </summary>
    /// <param name="newStatus">New status to set</param>
    public void UpdateStatus(JobStatus newStatus)
    {
        Status = newStatus;
    }
}

/// <summary>
/// Represents the possible statuses of a job posting
/// </summary>
public enum JobStatus
{
    /// <summary>
    /// Job is open for applications
    /// </summary>
    Open,
    
    /// <summary>
    /// Job is closed for applications
    /// </summary>
    Closed,
    
    /// <summary>
    /// Job is on hold
    /// </summary>
    OnHold,
    
    /// <summary>
    /// Job has been filled
    /// </summary>
    Filled
} 