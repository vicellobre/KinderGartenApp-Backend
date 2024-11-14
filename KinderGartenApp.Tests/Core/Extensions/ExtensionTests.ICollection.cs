using KinderGartenApp.Core.Extensions;

namespace KinderGartenApp.Tests.Core.Extensions;

public class CollectionExtensionsTests
{
    [Fact]
    public void IsEmpty_ShouldReturnTrue_WhenCollectionIsEmpty()
    {
        // Arrange
        List<int> collection = [];

        // Act
        var result = collection.IsEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsEmpty_ShouldReturnFalse_WhenCollectionIsNotEmpty()
    {
        // Arrange
        List<int> collection = [1];

        // Act
        var result = collection.IsEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNull_ShouldReturnTrue_WhenCollectionIsNull()
    {
        // Arrange
        List<int>? collection = null;

        // Act
        bool result = collection!.IsNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNull_ShouldReturnFalse_WhenCollectionIsNotNull()
    {
        // Arrange
        List<int> collection = [];

        // Act
        var result = collection.IsNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNullOrEmpty_ShouldReturnTrue_WhenCollectionIsNull()
    {
        // Arrange
        List<int>? collection = null;

        // Act
        var result = collection!.IsNullOrEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullOrEmpty_ShouldReturnTrue_WhenCollectionIsEmpty()
    {
        // Arrange
        List<int> collection = [];

        // Act
        var result = collection.IsNullOrEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullOrEmpty_ShouldReturnFalse_WhenCollectionIsNotNullOrEmpty()
    {
        // Arrange
        List<int> collection = [1];

        // Act
        var result = collection.IsNullOrEmpty();

        // Assert
        Assert.False(result);
    }
}
