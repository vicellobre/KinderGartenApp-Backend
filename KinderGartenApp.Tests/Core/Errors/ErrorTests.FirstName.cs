using KinderGartenApp.Core.Errors;

namespace KinderGartenApp.Tests.Core.Errors;

public partial class ErrorTests
{
    [Fact]
    public void FirstName_IsNullOrEmpty_ShouldHaveCorrectValues()
    {
        // Arrange
        var expectedCode = "FirstName.IsNullOrEmpty";
        var expectedMessage = "The first name cannot be empty.";

        // Act
        var error = Error.FirstName.IsNullOrEmpty;

        // Assert
        Assert.Equal(expectedCode, error.Code);
        Assert.Equal(expectedMessage, error.Message);
    }

    [Fact]
    public void FirstName_InvalidSpecialCharacters_ShouldHaveCorrectValues()
    {
        // Arrange
        var expectedCode = "FirstName.InvalidSpecialCharacters";
        var expectedMessage = "The first name can only contain alphabetic characters.";

        // Act
        var error = Error.FirstName.InvalidSpecialCharacters;

        // Assert
        Assert.Equal(expectedCode, error.Code);
        Assert.Equal(expectedMessage, error.Message);
    }

    [Fact]
    public void FirstName_TooLong_ShouldReturnCorrectValues()
    {
        // Arrange
        var length = 50;
        var expectedCode = "FirstName.TooLong";
        var expectedMessage = $"The first name cannot exceed {length} characters.";

        // Act
        var error = Error.FirstName.TooLong(length);

        // Assert
        Assert.Equal(expectedCode, error.Code);
        Assert.Equal(expectedMessage, error.Message);
    }
}
