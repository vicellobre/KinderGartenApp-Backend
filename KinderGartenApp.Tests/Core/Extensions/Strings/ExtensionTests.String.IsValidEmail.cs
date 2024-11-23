using KinderGartenApp.Core.Extensions;

namespace KinderGartenApp.Tests.Core.Extensions.Strings;

public partial class StringExtensionsTests
{
    [Fact]
    public void IsValidEmail_ShouldReturnTrue_ForValidEmail()
    {
        // Arrange
        var validEmail = "Alejandro@gmail.com";

        // Act
        var result = validEmail.IsValidEmail();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsValidEmail_ShouldReturnFalse_Empty()
    {
        // Arrange
        var validEmail = " ";

        // Act
        var result = validEmail.IsValidEmail();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidEmail_ShouldReturnFalse_NoNameFirst()
    {
        // Arrange
        var validEmail = "@gmail.com";

        // Act
        var result = validEmail.IsValidEmail();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidEmail_ShouldReturnFalse_NoAt()
    {
        // Arrange
        var validEmail = "Alejandrogmail.com";

        // Act
        var result = validEmail.IsValidEmail();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidEmail_ShouldReturnFalse_NoDomain()
    {
        // Arrange
        var validEmail = "Alejandro@.com";

        // Act
        var result = validEmail.IsValidEmail();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidEmail_ShouldReturnFalse_NoDot()
    {
        // Arrange
        var validEmail = "Alejandro@gmailcom";

        // Act
        var result = validEmail.IsValidEmail();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidEmail_ShouldReturnFalse_NoCom()
    {
        // Arrange
        var validEmail = "Alejandro@gmail.";

        // Act
        var result = validEmail.IsValidEmail();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidEmail_ShouldReturnFalse_ComToShort()
    {
        // Arrange
        var validEmail = "Alejandro@gmail.c";

        // Act
        var result = validEmail.IsValidEmail();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidEmail_ShouldReturnTrue_ComAtLeastWithTwoCharacters()
    {
        // Arrange
        var validEmail = "Alejandro@gmail.co";

        // Act
        var result = validEmail.IsValidEmail();

        // Assert
        Assert.True(result);
    }
}
