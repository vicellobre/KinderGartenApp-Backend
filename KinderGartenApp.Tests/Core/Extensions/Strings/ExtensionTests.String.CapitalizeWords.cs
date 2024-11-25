using KinderGartenApp.Core.Extensions;

namespace KinderGartenApp.Tests.Core.Extensions.Strings;

public partial class StringExtensionsTests
{
    [Fact]
    public void CapitalizeWords_ShouldCapitalizeCorrectly()
    {
        // Arrange
        string input = "  hello world";
        string expected = "Hello World";

        // Act
        string result = input.CapitalizeWords();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CapitalizeWords_ShouldHandleAlreadyCapitalized()
    {
        // Arrange
        string input = "Hello World  ";
        string expected = "Hello World";

        // Act
        string result = input.CapitalizeWords();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CapitalizeWords_ShouldHandleAllCaps()
    {
        // Arrange
        string input = "HELLO  WORLD";
        string expected = "Hello World";

        // Act
        string result = input.CapitalizeWords();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CapitalizeWords_ShouldHandleNewLines()
    {
        // Arrange
        string input = "hello\nworld";
        string expected = "Hello World";

        // Act
        string result = input.CapitalizeWords();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CapitalizeWords_ShouldHandleTabs()
    {
        // Arrange
        string input = "hello\tworld";
        string expected = "Hello World";

        // Act
        string result = input.CapitalizeWords();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CapitalizeWords_ShouldHandleCarriageReturns()
    {
        // Arrange
        string input = "hello\rworld";
        string expected = "Hello World";

        // Act
        string result = input.CapitalizeWords();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CapitalizeWords_ShouldHandleMultipleControlChars()
    {
        // Arrange
        string input = "hello\t\r\nworld";
        string expected = "Hello World";

        // Act
        string result = input.CapitalizeWords();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CapitalizeWords_ShouldHandleEmptyString()
    {
        // Arrange
        string input = "";
        string expected = "";

        // Act
        string result = input.CapitalizeWords();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CapitalizseWords_ShouldHandleWhiteSpace()
    {
        // Arrange
        string input = "  ";
        string expected = "";

        // Act
        string result = input.CapitalizeWords();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CapitalizeWords_ShouldHandleNullInput()
    {
        // Arrange
        string? input = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => input!.CapitalizeWords());
    }

    [Fact]
    public void CapitalizeWords_ShouldHandleMixedCase()
    {
        // Arrange
        string input = "hElLo WoRlD";
        string expected = "Hello World";

        // Act
        string result = input.CapitalizeWords();

        // Assert
        Assert.Equal(expected, result);
    }
}