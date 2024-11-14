using KinderGartenApp.Core.Errors;

namespace KinderGartenApp.Tests.Core.Errors;

public partial class ErrorTests
{
    [Fact]
    public void Create_WithValidArguments_ShouldCreateError()
    {
        // Arrange
        var code = "Error.Test";
        var message = "This is a test error.";

        // Act
        var error = Error.Create(code, message);

        // Assert
        Assert.Equal(code, error.Code);
        Assert.Equal(message, error.Message);
    }

    [Fact]
    public void Create_WithNullCode_ShouldThrowArgumentNullException()
    {
        // Arrange
        string? code = null;
        var message = "This is a test error.";

        // Act
        void Act() => Error.Create(code, message);

        // Assert
        Assert.Throws<ArgumentNullException>((Action)Act);
    }

    [Fact]
    public void Create_WithNullMessage_ShouldThrowArgumentNullException()
    {
        // Arrange
        var code = "Error.Test";
        string? message = null;

        // Act
        void Act() => Error.Create(code, message);

        // Assert
        Assert.Throws<ArgumentNullException>((Action)Act);
    }

    [Fact]
    public void Create_WithNullArguments_ShouldThrowArgumentNullException()
    {
        // Arrange
        string? code = null;
        string? message = null;

        // Act
        void Act() => Error.Create(code, message);

        // Assert
        Assert.Throws<ArgumentNullException>((Action)Act);
    }

    [Fact]
    public void Create_WithEmptyCode_ShouldUseDefaultCode()
    {
        // Arrange
        string? code = string.Empty;
        var message = "This is a test error.";

        // Act
        var error = Error.Create(code, message);

        // Assert
        Assert.Equal(Error.None.Code, error.Code);
        Assert.Equal(message, error.Message);
    }

    [Fact]
    public void Create_WithEmptyMessage_ShouldUseDefaultMessage()
    {
        // Arrange
        var code = "Error.Test";
        string? message = string.Empty;

        // Act
        var error = Error.Create(code, message);

        // Assert
        Assert.Equal(code, error.Code);
        Assert.Equal(Error.None.Message, error.Message);
    }

    [Fact]
    public void Create_WithEmptyArguments_ShouldUseDefaultValues()
    {
        // Arrange
        string code = string.Empty;
        string message = string.Empty;

        // Act
        var error = Error.Create(code, message);

        // Assert
        Assert.Equal(Error.None.Code, error.Code);
        Assert.Equal(Error.None.Message, error.Message);
    }
}
