namespace Api.Requests;

public class GetEmployeeByIdResponse
{
    public Guid Id { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public DateTime? DateOfBirth { get; init; }
    
    public static GetEmployeeByIdResponse FromEmployee(Employee Employee)
    {
        return new GetEmployeeByIdResponse
        {
            Id = Employee.Id,
            FirstName = Employee.FirstName,
            LastName = Employee.LastName,
            Email = Employee.Email,
            DateOfBirth = Employee.DateOfBirth
        };
    }
}