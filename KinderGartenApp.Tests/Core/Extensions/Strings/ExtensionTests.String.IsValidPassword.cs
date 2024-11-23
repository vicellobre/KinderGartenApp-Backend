using KinderGartenApp.Core.Extensions;

namespace KinderGartenApp.Tests.Core.Extensions.Strings;

public partial class StringExtensionsTests
{
    [Fact]
    public void IsValidPassword_ShouldReturnTrue_ForValidPassword()
    {
        // Arrange
        var validEmail = "123456789mM*";

        // Act
        var result = validEmail.IsValidPassword();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsValidPassword_ShouldReturnTrue_WithBlankSpace()
    {
        // Arrange
        var validEmail = "12345 6789 mM*";

        // Act
        var result = validEmail.IsValidPassword();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsValidPassword_ShouldReturnFalse_EmptyPassword()
    {
        // Arrange
        var validEmail = " ";

        // Act
        var result = validEmail.IsValidPassword();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidPassword_ShouldReturnFalse_NoNumbers()
    {
        // Arrange
        var validEmail = "mmmmmmMMMMM*";

        // Act
        var result = validEmail.IsValidPassword();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidPassword_ShouldReturnFalse_NoDownCase()
    {
        // Arrange
        var validEmail = "123456789MMMMM*";

        // Act
        var result = validEmail.IsValidPassword();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidPassword_ShouldReturnFalse_NoUpperCase()
    {
        // Arrange
        var validEmail = "123456789mmmmm*";

        // Act
        var result = validEmail.IsValidPassword();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidPassword_ShouldReturnFalse_NoSpetialCharacters()
    {
        // Arrange
        var validEmail = "123456789mM";

        // Act
        var result = validEmail.IsValidPassword();

        // Assert
        Assert.False(result);
    }
}
