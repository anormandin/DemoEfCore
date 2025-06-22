namespace Api.Domain;

public class Employer: Entity<Guid>
{
    public required string Name { get; init; }
    public required string Address { get; init; }
    public required string City { get; init; }
    public required string State { get; init; }
    public string? PhoneNumber { get; init; }
    
}