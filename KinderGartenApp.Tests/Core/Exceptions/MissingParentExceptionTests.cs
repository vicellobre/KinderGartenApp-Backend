using KinderGartenApp.Core.Exceptions;

namespace KinderGartenApp.Tests.Core.Exceptions;

public class MissingParentExceptionTests
{
    [Fact]
    public void MissingParentException_DefaultConstructor_ShouldSetDefaultMessage()
    {
        // Act
        var exception = new MissingParentException();

        // Assert
        Assert.Equal("Parent must be set before performing this operation.", exception.Message);
    }

    [Fact]
    public void MissingParentException_MessageConstructor_ShouldSetCustomMessage()
    {
        // Arrange
        string customMessage = "Custom error message.";

        // Act
        var exception = new MissingParentException(customMessage);

        // Assert
        Assert.Equal(customMessage, exception.Message);
    }

    [Fact]
    public void MissingParentException_MessageAndInnerExceptionConstructor_ShouldSetMessageAndInnerException()
    {
        // Arrange
        string customMessage = "Custom error message.";
        var innerException = new Exception("Inner exception message.");

        // Act
        var exception = new MissingParentException(customMessage, innerException);

        // Assert
        Assert.Equal(customMessage, exception.Message);
        Assert.Equal(innerException, exception.InnerException);
    }
}