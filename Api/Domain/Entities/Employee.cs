namespace Api.Domain.Entities;

public class Employee: Entity<Guid>
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public DateTime? DateOfBirth { get; init; }
}