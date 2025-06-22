namespace Api.Domain;

public class Job: Entity<Guid>
{
    public required int PositionId { get; init; }
    public required DateTime StartedAtUtc { get; init; }
    public required DateTime FinishedAtUtc { get; init; }
    public required Guid EmployerId { get; init; }
    public required Guid EmployeeId { get; init; }
    
    // Navigation property
    public Employer? Employer { get; private set; }
    public Employee? Employee { get; private set; }
    
}