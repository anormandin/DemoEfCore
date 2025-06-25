using Api.Application.Errors;
using Api.Requests;

namespace Api.Application.Services;

public interface IEmployeeService : IService
{
    ErrorOr<Employee> GetById(Guid id);
    ErrorOr<Employee> Add(Employee employee);
}

public class EmployeeService : IEmployeeService
{
    public ErrorOr<Employee> GetById(Guid id)
    {
        return EmployeeErrors.NotFound(id);
    }

    public ErrorOr<Employee> Add(Employee employee)
    {
        // TODO: Save Employee to the database

        return employee;
    }

    public ErrorOr<Employee> Update(Employee employee)
    {
        // TODO: Update Employee in the database
        return employee;
    }
}