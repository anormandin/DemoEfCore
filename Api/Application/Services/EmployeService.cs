using Api.Application.Errors;
using Api.Requests;

namespace Api.Application.Services;

public interface IEmployeService : IService
{
    ErrorOr<Employee> GetById(GetEmployeByIdRequest request);
    ErrorOr<Employee> Create(CreateEmployeRequest request);
}

public class EmployeService : IEmployeService
{
    private readonly ValidationService _validationService;

    public EmployeService(ValidationService validationService)
    {
        _validationService = validationService;
    }

    public ErrorOr<Employee> GetById(GetEmployeByIdRequest request)
    {
        return EmployeErrors.NotFound(request.Id);
    }

    public ErrorOr<Employee> Create(CreateEmployeRequest request)
    {
        var validationResult = _validationService.Validate(request);
        if (!validationResult.IsValid)
        {
            return validationResult.ToErrorList();
        }

        var employee = Employee.Create(request);

        // TODO: Save employee to the database
        return employee;
    }
}