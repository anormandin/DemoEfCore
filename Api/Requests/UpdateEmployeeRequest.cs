namespace Api.Requests;

public class UpdateEmployeeRequest
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
}