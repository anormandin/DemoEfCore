using Api.Domain;
using Api.Domain.Entities;

namespace Api.Tests;

public class EmployerTests
{
    [Fact]
    public void Employer_WhenCreated_IsSuccess()
    {
        // Arrange
        var employer = Employer.Create(
            "Tech Solutions",
            "123 Tech Lane",
            "Tech City",
            "TS",
            "123-456-7890"
        );

        // Act & Assert
        Assert.NotNull(employer);
        Assert.Equal("Tech Solutions", employer.Name);
        Assert.Equal("123 Tech Lane", employer.Address);
        Assert.Equal("Tech City", employer.City);
        Assert.Equal("TS", employer.State);

        // Act & Assert
        Assert.NotNull(employer);
        Assert.Equal("Tech Solutions", employer.Name);
        Assert.Equal("123 Tech Lane", employer.Address);
        Assert.Equal("Tech City", employer.City);
        Assert.Equal("TS", employer.State);
        Assert.Equal("123-456-7890", employer.PhoneNumber);
    }
}