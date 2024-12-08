using KinderGartenApp.Application.Filters;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Exceptions;

namespace KinderGartenApp.Tests.Application.Filters;

public partial class ParentFilterTests
{
    [Fact]
    public void Get_ShouldReturnParent_WhenParentIsSet()
    {
        // Arrange
        var parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "12345678mM*", "1234567890");
        var filter = new ParentFilter().Set(parent);

        // Act
        var result = filter.Get();

        // Assert
        Assert.Equal(parent, result);
    }

    [Fact]
    public void Get_ShouldThrowMissingParentException_WhenParentIsNotSet()
    {
        // Arrange
        var filter = new ParentFilter();

        // Act & Assert
        Assert.Throws<MissingParentException>(filter.Get);
    }

    [Fact]
    public void Set_ShouldThrowArgumentNullException_WhenParentIsNull()
    {
        Parent? parent = null;

        // Arrange
        var filter = new ParentFilter();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => filter.Set(parent!));
    }
}
