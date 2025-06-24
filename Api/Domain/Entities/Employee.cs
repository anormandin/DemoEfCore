using Api.Requests;

namespace Api.Domain.Entities;

public class Employee : Entity<Guid>
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public DateTime? DateOfBirth { get; init; }

    // Ef Core
    private Employee() { }

    public static Employee Create(CreateEmployeRequest request)
    {
        var employee = new Employee
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth
        };

        return employee;
    }
}