using Api.Application.Controllers;
using Api.Application.Services;
using Api.Domain.Entities;
using Api.Domain.Validation;
using Api.Requests;
using Api.Tests.Application.Services;

using FluentValidation.Results;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Tests.Controllers;

public class DemoEfCoreControllerTests : IClassFixture<ApiTestFixture>
{
    private readonly EmployeeController _controller;
    private readonly IEmployeeService _employeeService;

    public DemoEfCoreControllerTests(ApiTestFixture fixture)
    {
        _employeeService = fixture.GetEmployeeService();

        _controller = new EmployeeController(_employeeService,
            fixture.ServiceProvider.GetRequiredService<ValidationService>());
    }

    [Fact]
    public void GetById_WhenEmployeeExists_ReturnsOkResult()
    {
        // Arrange
        var testEmployee = Employee.Create(
            firstName: "John",
            lastName: "Doe",
            email: "j.doe@example.com",
            dateOfBirth: DateTime.UtcNow.AddYears(-30)
        );
        var addResult = _employeeService.Add(testEmployee);
        Assert.False(addResult.IsError, "Failed to add test employee");

        var employeeId = testEmployee.Id;
        var request = new GetEmployeeByIdRequest { Id = employeeId };

        // Act
        var result = _controller.GetById(request);

        // Assert
        Assert.IsType<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.NotNull(okResult);
        Assert.IsType<Employee>(okResult.Value);
        Assert.Equal(employeeId, ((Employee)okResult.Value).Id);
    }

    [Fact]
    public void GetById_WhenEmployeeDoesNotExist_ReturnsNotFoundResult()
    {
        // Arrange
        var nonExistentId = Guid.NewGuid();
        var request = new GetEmployeeByIdRequest { Id = nonExistentId };

        // Act
        var result = _controller.GetById(request);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result);
    }

    [Fact]
    public void Create_WithValidData_ReturnsCreatedAtActionResult()
    {
        // Arrange
        var request = new CreateEmployeeRequest
        {
            FirstName = "Jane",
            LastName = "Smith",
            Email = "j.smith@example.com",
            DateOfBirth = DateTime.UtcNow.AddYears(-25)
        };

        // Act
        var result = _controller.Create(request);

        // Assert
        Assert.IsType<CreatedAtActionResult>(result);
        var createdResult = result as CreatedAtActionResult;
        Assert.NotNull(createdResult);
        Assert.Equal(nameof(EmployeeController.GetById), createdResult.ActionName);
        Assert.IsType<Employee>(createdResult.Value);

        var createdEmployee = createdResult.Value as Employee;
        Assert.NotNull(createdEmployee);
        Assert.Equal(request.FirstName, createdEmployee.FirstName);
        Assert.Equal(request.LastName, createdEmployee.LastName);
        Assert.Equal(request.Email, createdEmployee.Email);
        Assert.NotEqual(Guid.Empty, createdEmployee.Id);
        Assert.NotNull(createdResult.RouteValues?["id"]);
        Assert.Equal(createdEmployee.Id, createdResult.RouteValues["id"]);

        // Verify the employee was actually created in the service
        var getResult = _employeeService.GetById(createdEmployee.Id);
        Assert.False(getResult.IsError);
        Assert.Equal(createdEmployee.Id, getResult.Value.Id);
    }

    [Fact]
    public void Create_WithInvalidData_ReturnsBadRequestResult()
    {
        // Arrange
        var request = new CreateEmployeeRequest
        {
            FirstName = "", // Empty first name should be invalid
            LastName = "Smith",
            Email = "invalid-email", // Invalid email format
            DateOfBirth = DateTime.UtcNow.AddYears(5) // Future date should be invalid
        };

        // Act
        var result = _controller.Create(request);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
        var badRequestResult = result as BadRequestObjectResult;
        Assert.NotNull(badRequestResult);
        Assert.NotNull(badRequestResult.Value);

        // The error response should contain validation errors
        var errorFields = badRequestResult.Value as List<ValidationFailure>;
        Assert.NotNull(errorFields);
        Assert.Contains(errorFields, e => e.PropertyName == "FirstName");
        Assert.Contains(errorFields, e => e.PropertyName == "Email");
        Assert.Contains(errorFields, e => e.PropertyName == "DateOfBirth");
    }
}