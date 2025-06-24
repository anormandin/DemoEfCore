namespace Api.Requests;

public class GetEmployeByIdRequestResponse
{
    public Guid Id { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public DateTime? DateOfBirth { get; init; }
    
}