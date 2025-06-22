namespace Api.Domain.Entities;

public class Employer: Entity<Guid>
{
    public required string Name { get; init; }
    public required string Address { get; init; }
    public required string City { get; init; }
    public required string State { get; init; }
    public string? PhoneNumber { get; init; }
    
    private Employer() { }
    
    public static Employer Create(
        string name,
        string address,
        string city,
        string state,
        string? phoneNumber = null)
    {
        return new Employer
        {
            Id = Guid.NewGuid(),
            Name = name,
            Address = address,
            City = city,
            State = state,
            PhoneNumber = phoneNumber
        };
    }
}