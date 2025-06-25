namespace Api.Domain.Entities;

public class Job: Entity<Guid>
{

    public int PositionId { get; init; }
    public DateTime StartedAtUtc { get; init; }
    public DateTime FinishedAtUtc { get; init; }
    public Guid EmployeerId { get; init; }
    public Guid EmployeeId { get; init; }

    private Job(Guid id, int positionId, DateTime startedAtUtc, DateTime finishedAtUtc, Guid employeerId,
        Guid employeeId, Employer? employer, Employee? employee) : base(id)
    {
        PositionId = positionId;
        StartedAtUtc = startedAtUtc;
        FinishedAtUtc = finishedAtUtc;
        EmployeerId = employeerId;
        EmployeeId = employeeId;
        Employer = employer;
        Employee = employee;
    }

    // Navigation property
    public Employer? Employer { get; private set; }
    public Employee? Employee { get; private set; }
    
}