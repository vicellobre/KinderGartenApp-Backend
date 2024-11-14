using KinderGartenApp.Core.Extensions;

namespace KinderGartenApp.Tests.Core.Extensions.ICollections;

public partial class CollectionExtensionsTests
{
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
