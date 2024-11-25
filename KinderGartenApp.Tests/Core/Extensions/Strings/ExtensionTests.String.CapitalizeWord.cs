using KinderGartenApp.Core.Extensions;

namespace KinderGartenApp.Tests.Core.Extensions.Strings;

public partial class StringExtensionsTests
{
    [Fact]
    public void CapitalizeWord_ShouldCapitalizeCorrectly()
    {
        // Arrange
        string input = "example";
        string expected = "Example";

        // Act
        string result = input.CapitalizeWord();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CapitalizeWord_ShouldHandleAlreadyCapitalized()
    {
        // Arrange
        string input = "Example";
        string expected = "Example";

        // Act
        string result = input.CapitalizeWord();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CapitalizeWord_ShouldHandleAllCaps()
    {
        // Arrange
        string input = "EXAMPLE";
        string expected = "Example";

        // Act
        string result = input.CapitalizeWord();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CapitalizeWord_ShouldHandleSingleCharacter()
    {
        // Arrange
        string input = "e";
        string expected = "E";

        // Act
        string result = input.CapitalizeWord();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CapitalizeWord_ShouldHandleEmptyString()
    {
        // Arrange
        string input = "";

        // Act & Assert
        Assert.Throws<ArgumentNullException>(input.CapitalizeWord);
    }

    [Fact]
    public void CapitalizeWord_ShouldHandleWhiteSpaces()
    {
        // Arrange
        string input = "  ";

        // Act & Assert
        Assert.Throws<ArgumentNullException>(input.CapitalizeWord);
    }

    [Fact]
    public void CapitalizeWord_ShouldHandleNullInput()
    {
        // Arrange
        string? input = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => input!.CapitalizeWord());
    }

    [Fact]
    public void CapitalizeWord_ShouldHandleMixedCase()
    {
        // Arrange
        string input = "eXaMpLe";
        string expected = "Example";

        // Act
        string result = input.CapitalizeWord();

        // Assert
        Assert.Equal(expected, result);
    }
}