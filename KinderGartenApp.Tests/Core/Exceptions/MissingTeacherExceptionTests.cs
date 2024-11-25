using KinderGartenApp.Core.Exceptions;

namespace KinderGartenApp.Tests.Core.Exceptions;

public class MissingTeacherExceptionTests
{
    [Fact]
    public void MissingTeacherException_DefaultConstructor_ShouldSetDefaultMessage()
    {
        // Act
        var exception = new MissingTeacherException();

        // Assert
        Assert.Equal("Teacher must be set before performing this operation.", exception.Message);
    }

    [Fact]
    public void MissingTeacherException_MessageConstructor_ShouldSetCustomMessage()
    {
        // Arrange
        string customMessage = "Custom error message.";

        // Act
        var exception = new MissingTeacherException(customMessage);

        // Assert
        Assert.Equal(customMessage, exception.Message);
    }

    [Fact]
    public void MissingTeacherException_MessageAndInnerExceptionConstructor_ShouldSetMessageAndInnerException()
    {
        // Arrange
        string customMessage = "Custom error message.";
        var innerException = new Exception("Inner exception message.");

        // Act
        var exception = new MissingTeacherException(customMessage, innerException);

        // Assert
        Assert.Equal(customMessage, exception.Message);
        Assert.Equal(innerException, exception.InnerException);
    }
}