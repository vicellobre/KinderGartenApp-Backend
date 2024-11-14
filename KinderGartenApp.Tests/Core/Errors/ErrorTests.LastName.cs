using KinderGartenApp.Core.Errors;

namespace KinderGartenApp.Tests.Core.Errors;

public partial class ErrorTests
{
    [Fact]
    public void LastName_IsNullOrEmpty_ShouldHaveCorrectValues()
    {
        // Arrange
        var expectedCode = "LastName.IsNullOrEmpty";
        var expectedMessage = "The last name cannot be empty.";

        // Act
        var error = Error.LastName.IsNullOrEmpty;

        // Assert
        Assert.Equal(expectedCode, error.Code);
        Assert.Equal(expectedMessage, error.Message);
    }

    [Fact]
    public void LastName_InvalidSpecialCharacters_ShouldHaveCorrectValues()
    {
        // Arrange
        var expectedCode = "LastName.InvalidSpecialCharacters";
        var expectedMessage = "The last name can only contain alphabetic characters.";

        // Act
        var error = Error.LastName.InvalidSpecialCharacters;

        // Assert
        Assert.Equal(expectedCode, error.Code);
        Assert.Equal(expectedMessage, error.Message);
    }

    [Fact]
    public void LastName_TooLong_ShouldReturnCorrectValues()
    {
        // Arrange
        var length = 50;
        var expectedCode = "LastName.TooLong";
        var expectedMessage = $"The last name cannot exceed {length} characters.";

        // Act
        var error = Error.LastName.TooLong(length);

        // Assert
        Assert.Equal(expectedCode, error.Code);
        Assert.Equal(expectedMessage, error.Message);
    }
}
