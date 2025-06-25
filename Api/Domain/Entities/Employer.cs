namespace Api.Domain.Entities;

public class Employer : Entity<Guid>
{
    public string Name { get; init; }
    public string Address { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string? PhoneNumber { get; init; }

    private Employer(Guid id, string name, string address, string city, string state, string? phoneNumber) : base(id)
    {
        Name = name;
        Address = address;
        City = city;
        State = state;
        PhoneNumber = phoneNumber;
    }

    public static Employer Create(
        string name,
        string address,
        string city,
        string state,
        string? phoneNumber = null)
    {
        return new Employer(
            id: Guid.NewGuid(),
            name: name,
            address: address,
            city: city,
            state: state,
            phoneNumber: phoneNumber
        );
    }
}