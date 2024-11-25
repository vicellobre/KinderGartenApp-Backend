using KinderGartenApp.Core.Extensions;

namespace KinderGartenApp.Tests.Core.Extensions.Strings;

public partial class StringExtensionsTests
{
    [Fact]
    public void ReplaceControlCharsWithSpace_ShouldReplaceTabWithSpace()
    {
        // Arrange
        string input = "Hello\tWorld";
        string expected = "Hello World";

        // Act
        string result = input.ReplaceControlCharsWithSpace();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ReplaceControlCharsWithSpace_ShouldReplaceNewLineWithSpace()
    {
        // Arrange
        string input = "Hello\nWorld";
        string expected = "Hello World";

        // Act
        string result = input.ReplaceControlCharsWithSpace();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ReplaceControlCharsWithSpace_ShouldReplaceCarriageReturnWithSpace()
    {
        // Arrange
        string input = "Hello\rWorld";
        string expected = "Hello World";

        // Act
        string result = input.ReplaceControlCharsWithSpace();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ReplaceControlCharsWithSpace_ShouldReplaceMultipleControlCharsWithSpace()
    {
        // Arrange
        string input = "Hello\t\r\nWorld";
        string expected = "Hello   World";

        // Act
        string result = input.ReplaceControlCharsWithSpace();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ReplaceControlCharsWithSpace_ShouldHandleEmptyString()
    {
        // Arrange
        string input = "";
        string expected = "";

        // Act
        string result = input.ReplaceControlCharsWithSpace();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ReplaceControlCharsWithSpace_ShouldHandleWhiteSpace()
    {
        // Arrange
        string input = " ";
        string expected = " ";

        // Act
        string result = input.ReplaceControlCharsWithSpace();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ReplaceControlCharsWithSpace_ShouldHandleNullInput()
    {
        // Arrange
        string? input = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => input!.ReplaceControlCharsWithSpace());
    }
}