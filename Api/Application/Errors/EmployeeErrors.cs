namespace Api.Application.Errors;

public static class EmployeeErrors
{
    public static Error NotFound(Guid id) => Error.NotFound($"Employee with id {id} not found.");
    public static Error AlreadyExists(string email) => Error.Validation($"Employee with email {email} already exists.");
}