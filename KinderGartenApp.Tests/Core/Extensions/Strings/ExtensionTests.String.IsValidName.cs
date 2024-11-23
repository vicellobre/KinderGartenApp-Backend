using KinderGartenApp.Core.Extensions;

namespace KinderGartenApp.Tests.Core.Extensions.Strings;

public partial class StringExtensionsTests
{
    [Fact]
    public void IsValidPersonName_ShouldReturnTrue_ForValidName()
    {
        // Arrange
        var validName = "María";

        // Act
        var result = validName.IsValidPersonName();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsValidPersonName_ShouldReturnFalse_ForInvalidNameWithNumbers()
    {
        // Arrange
        var invalidName = "María123";

        // Act
        var result = invalidName.IsValidPersonName();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidPersonName_ShouldReturnFalse_ForInvalidNameWithSpecialCharacters()
    {
        // Arrange
        var invalidName = "María@";

        // Act
        var result = invalidName.IsValidPersonName();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidPersonName_ShouldReturnTrue_ForValidNameWithAccents()
    {
        // Arrange
        var validName = "José";

        // Act
        var result = validName.IsValidPersonName();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsValidPersonName_ShouldReturnTrue_ForValidNameWithSpecialCharacters()
    {
        // Arrange
        var validName = "François";

        // Act
        var result = validName.IsValidPersonName();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsValidPersonName_ShouldReturnTrue_ForValidNameWithSpace()
    {
        // Arrange
        var validName = "María José";

        // Act
        var result = validName.IsValidPersonName();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsValidPersonName_ShouldReturnFalse_ForInvalidNameWithMultipleSpaces()
    {
        // Arrange
        var invalidName = "María    José";

        // Act
        var result = invalidName.IsValidPersonName();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidPersonName_ShouldReturnFalse_ForEmptyString()
    {
        // Arrange
        var invalidName = "";

        // Act
        var result = invalidName.IsValidPersonName();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidPersonName_ShouldReturnFalse_ForStringWithOnlySpaces()
    {
        // Arrange
        var invalidName = "   ";

        // Act
        var result = invalidName.IsValidPersonName();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidPersonName_ShouldReturnFalse_ForStringStartingWithSpace()
    {
        // Arrange
        var invalidName = " María";

        // Act
        var result = invalidName.IsValidPersonName();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidPersonName_ShouldReturnFalse_ForStringEndingWithSpace()
    {
        // Arrange
        var invalidName = "María ";

        // Act
        var result = invalidName.IsValidPersonName();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidPersonName_ShouldReturnTrue_ForNameWithRepeatedCharacters()
    {
        // Arrange
        var validName = "Sofía María";

        // Act
        var result = validName.IsValidPersonName();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsValidPersonName_ShouldReturnTrue_ForNameWithConsecutiveRepeatedCharacters()
    {
        // Arrange
        var validName = "Anna María";

        // Act
        var result = validName.IsValidPersonName();

        // Assert
        Assert.True(result);
    }
}
