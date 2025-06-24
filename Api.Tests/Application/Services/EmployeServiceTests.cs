using Api.Application.Services;
using Api.Requests;
using Microsoft.Extensions.DependencyInjection;
using System;

using Xunit;

namespace Api.Tests.Application.Services;

public class EmployeServiceTests : IClassFixture<ApiTestFixture>
{
    private readonly ApiTestFixture _fixture;

    public EmployeServiceTests(ApiTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Create_WithValidRequest_ReturnsEmployee()
    {
        // Arrange
        var service = _fixture.ServiceProvider.GetRequiredService<IEmployeService>();
        var request = new CreateEmployeRequest 
        { 
            FirstName = "John", 
            LastName = "Doe", 
            Email = "john.doe@example.com",
            DateOfBirth = DateTime.UtcNow.AddYears(-30)
        };

        // Act
        var result = service.Create(request);

        // Assert
        Assert.False(result.IsError);
        Assert.Equal(request.FirstName, result.Value.FirstName);
        Assert.Equal(request.LastName, result.Value.LastName);
        Assert.Equal(request.Email, result.Value.Email);
        Assert.Equal(request.DateOfBirth, result.Value.DateOfBirth);
    }

    [Fact]
    public void Create_WithEmptyFirstName_ReturnsValidationError()
    {
        // Arrange
        var service = _fixture.ServiceProvider.GetRequiredService<IEmployeService>();
        var request = new CreateEmployeRequest 
        { 
            FirstName = "", 
            LastName = "Smith", 
            Email = "smith@example.com" 
        };

        // Act
        var result = service.Create(request);

        // Assert
        Assert.True(result.IsError);
        Assert.Contains(result.Errors, e => e.Code == "FirstName");
    }

    [Fact]
    public void Create_WithEmptyLastName_ReturnsValidationError()
    {
        // Arrange
        var service = _fixture.ServiceProvider.GetRequiredService<IEmployeService>();
        var request = new CreateEmployeRequest 
        { 
            FirstName = "Jane", 
            LastName = "", 
            Email = "jane@example.com" 
        };

        // Act
        var result = service.Create(request);

        // Assert
        Assert.True(result.IsError);
        Assert.Contains(result.Errors, e => e.Code == "LastName");
    }

    [Fact]
    public void Create_WithInvalidEmail_ReturnsValidationError()
    {
        // Arrange
        var service = _fixture.ServiceProvider.GetRequiredService<IEmployeService>();
        var request = new CreateEmployeRequest 
        { 
            FirstName = "Jane", 
            LastName = "Smith", 
            Email = "not-valid-email" 
        };

        // Act
        var result = service.Create(request);

        // Assert
        Assert.True(result.IsError);
        Assert.Contains(result.Errors, e => e.Code == "Email");
    }

    [Fact]
    public void Create_WithFutureDateOfBirth_ReturnsValidationError()
    {
        // Arrange
        var service = _fixture.ServiceProvider.GetRequiredService<IEmployeService>();
        var request = new CreateEmployeRequest 
        { 
            FirstName = "Jane", 
            LastName = "Smith", 
            Email = "jane@example.com",
            DateOfBirth = DateTime.UtcNow.AddDays(1)
        };

        // Act
        var result = service.Create(request);

        // Assert
        Assert.True(result.IsError);
        Assert.Contains(result.Errors, e => e.Code == "DateOfBirth");
    }

    [Fact]
    public void Create_WithMultipleValidationErrors_ReturnsAllErrors()
    {
        // Arrange
        var service = _fixture.ServiceProvider.GetRequiredService<IEmployeService>();
        var request = new CreateEmployeRequest 
        { 
            FirstName = "", 
            LastName = "", 
            Email = "invalid-email",
            DateOfBirth = DateTime.UtcNow.AddDays(1)
        };

        // Act
        var result = service.Create(request);

        // Assert
        Assert.True(result.IsError);
        Assert.Contains(result.Errors, e => e.Code == "FirstName");
        Assert.Contains(result.Errors, e => e.Code == "LastName");
        Assert.Contains(result.Errors, e => e.Code == "Email");
        Assert.Contains(result.Errors, e => e.Code == "DateOfBirth");
    }
}