using Api.Domain.ValueObjects;

namespace Api.Tests.Domain.ValueObjects;

public class PhoneNumberTests
{
    [Theory]
    [InlineData("123-456-7890")]
    [InlineData("(123) 456-7890")]
    [InlineData("1234567890")]
    public void PhoneNumber_ShouldNotThrow_WhenFormatIsCorrect(string phoneNumber)
    {
        // Act & Assert
        var exception = Record.Exception(() => new PhoneNumber(phoneNumber));
        Assert.Null(exception);
    }

    [Theory]
    [InlineData("12345")]
    [InlineData("abc-def-ghij")]
    [InlineData("")]
    [InlineData("123-45-6789")]
    [InlineData("(123) 45-6789")]
    public void PhoneNumber_ShouldThrowException_WhenFormatIsIncorrect(string phoneNumber)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new PhoneNumber(phoneNumber));
    }
}