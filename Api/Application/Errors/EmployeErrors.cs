namespace Api.Application.Errors;

public static class EmployeErrors
{
    public static Error NotFound(Guid id) => Error.NotFound($"Employe with id {id} not found.");
    public static Error AlreadyExists(string email) => Error.Validation($"Employe with email {email} already exists.");
}