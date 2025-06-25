using Api.Application.Services;
using Api.Requests;

namespace Api.Domain.Entities;

public class Employee : Entity<Guid>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public DateTime? DateOfBirth { get; private set; }

    private Employee(Guid id, string firstName, string lastName, string email, DateTime? dateOfBirth) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        DateOfBirth = dateOfBirth;
    }

    public static Employee Create(
        string firstName, string lastName, string email, DateTime? dateOfBirth)
    {
        return new Employee(Guid.NewGuid(), firstName, lastName, email, dateOfBirth);
    }

    public Employee Update(string firstName, string lastName, string email, DateTime? dateOfBirth)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        DateOfBirth = dateOfBirth;

        return this;
    }
}