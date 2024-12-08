using KinderGartenApp.Application.Filters;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Exceptions;

namespace KinderGartenApp.Tests.Application.Filters;

public partial class ParentFilterTests
{
    [Fact]
    public void NormalizeLastName_ShouldNormalizeLastName_WhenParentIsSet()
    {
        // Arrange
        var parent = Parent.Create(Guid.NewGuid(), "David", " martinez", "David@gmail.com", "12345678mM*", "1234567890");
        var filter = new ParentFilter().Set(parent);

        // Act
        filter.NormalizeLastName();

        // Assert
        Assert.Equal("Martinez", parent.LastName);
    }

    [Fact]
    public void NormalizeLastName_ShouldNormalizeLastNameToEmpty_WhenLastNameIsNull()
    {
        // Arrange
        var parent = Parent.Create(Guid.NewGuid(), "David", null, "David@gmail.com", "12345678mM*", "1234567890");
        var filter = new ParentFilter().Set(parent);

        // Act
        filter.NormalizeLastName();

        // Assert
        Assert.Equal(string.Empty, parent.LastName);
    }

    [Fact]
    public void NormalizeLastName_ShouldNormalizeLastNameToEmpty_WhenLastNameIsEmpty()
    {
        // Arrange
        var parent = Parent.Create(Guid.NewGuid(), "David", "", "David@gmail.com", "12345678mM*", "1234567890");
        var filter = new ParentFilter().Set(parent);

        // Act
        filter.NormalizeLastName();

        // Assert
        Assert.Equal(string.Empty, parent.LastName);
    }

    [Fact]
    public void NormalizeLastName_ShouldNormalizeLastNameToEmpty_WhenLastNameIsWhiteSpace()
    {
        // Arrange
        var parent = Parent.Create(Guid.NewGuid(), "David", "   ", "David@gmail.com", "12345678mM*", "1234567890");
        var filter = new ParentFilter().Set(parent);

        // Act
        filter.NormalizeLastName();

        // Assert
        Assert.Equal(string.Empty, parent.LastName);
    }

    [Fact]
    public void NormalizeLastName_ShouldThrowMissingParentException_WhenParentIsNotSet()
    {
        // Arrange
        var filter = new ParentFilter();

        // Act & Assert
        Assert.Throws<MissingParentException>(filter.NormalizeLastName);
    }
}
