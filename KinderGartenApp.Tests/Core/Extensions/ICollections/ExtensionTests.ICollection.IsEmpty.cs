using KinderGartenApp.Core.Extensions;

namespace KinderGartenApp.Tests.Core.Extensions.ICollections;

public partial class CollectionExtensionsTests
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
}
