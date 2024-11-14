using KinderGartenApp.Core.Errors;

namespace KinderGartenApp.Tests.Core.Errors;

public partial class ErrorTests
{
    [Fact]
    public void None_ShouldHaveEmptyCodeAndMessage()
    {
        // Arrange
        string expectedCode = string.Empty;
        string expectedMessage = string.Empty;

        // Act
        Error error = Error.None;

        // Assert
        Assert.Equal(expectedCode, error.Code);
        Assert.Equal(expectedMessage, error.Message);
    }

    [Fact]
    public void NullValue_ShouldHaveNullValueCodeAndMessage()
    {
        // Arrange
        var expectedCode = "Error.NullValue";
        var expectedMessage = "The specified result value is null.";

        // Act
        var error = Error.NullValue;

        // Assert
        Assert.Equal(expectedCode, error.Code);
        Assert.Equal(expectedMessage, error.Message);
    }

    [Fact]
    public void Unknown_ShouldHaveUnknownCodeAndMessage()
    {
        // Arrange
        var expectedCode = "Error.Unknown";
        var expectedMessage = "An unknown error occurred.";

        // Act
        var error = Error.Unknown;

        // Assert
        Assert.Equal(expectedCode, error.Code);
        Assert.Equal(expectedMessage, error.Message);
    }
}
