namespace Api.Requests;

public class GetEmployeeByIdRequest
{
    public required Guid Id { get; init; }
}