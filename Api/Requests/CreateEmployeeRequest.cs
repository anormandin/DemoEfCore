namespace Api.Requests;

public class CreateEmployeeRequest
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public DateTime? DateOfBirth { get; init; }

    public Employee ToEmployee()
    {
        return Employee.Create(
            firstName: FirstName,
            lastName: LastName,
            email: Email,
            dateOfBirth: DateOfBirth);
    }
}