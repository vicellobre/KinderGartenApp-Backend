using KinderGartenApp.Core.Extensions;

namespace KinderGartenApp.Tests.Core.Extensions.Strings;

public partial class StringExtensionsTests
{
    [Fact]
    public void IsValidPhone_ShouldReturnTrue_ForValidPhone()
    {
        // Arrange
        var validEmail = "1234567890";

        // Act
        var result = validEmail.IsValidPhone();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsValidPhone_ShouldReturnFalse_noNumbers()
    {
        // Arrange
        var validEmail = "asdfghjklñ";

        // Act
        var result = validEmail.IsValidPhone();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidPhone_ShouldReturnFalse_WithLetters()
    {
        // Arrange
        var validEmail = "1234567890asd";

        // Act
        var result = validEmail.IsValidPhone();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidPhone_ShouldReturnFalse_WithSpecialCharacters()
    {
        // Arrange
        var validEmail = "123456789*";

        // Act
        var result = validEmail.IsValidPhone();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidPhone_ShouldReturnFalse_MoreThenTenNumbers()
    {
        // Arrange
        var validEmail = "12345678900";

        // Act
        var result = validEmail.IsValidPhone();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidPhone_ShouldReturnFalse_LessThenTenNumbers()
    {
        // Arrange
        var validEmail = "123456789";

        // Act
        var result = validEmail.IsValidPhone();

        // Assert
        Assert.False(result);
    }
}
