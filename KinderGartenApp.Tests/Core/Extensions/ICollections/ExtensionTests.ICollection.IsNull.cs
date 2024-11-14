using KinderGartenApp.Core.Extensions;

namespace KinderGartenApp.Tests.Core.Extensions.ICollections;

public partial class CollectionExtensionsTests
{
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
}
