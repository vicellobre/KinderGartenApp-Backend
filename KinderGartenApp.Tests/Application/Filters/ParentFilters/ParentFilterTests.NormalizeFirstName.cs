using KinderGartenApp.Application.Filters;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Exceptions;

namespace KinderGartenApp.Tests.Application.Filters;

public partial class ParentFilterTests
{
    [Fact]
    public void NormalizeFirstName_ShouldNormalizeFirstName_WhenParentIsSet()
    {
        // Arrange
        var parent = Parent.Create(Guid.NewGuid(), " david", "Martinez", "David@gmail.com", "12345678mM*", "1234567890");
        var filter = new ParentFilter().Set(parent);

        // Act
        filter.NormalizeFirstName();

        // Assert
        Assert.Equal("David", parent.FirstName);
    }

    [Fact]
    public void NormalizeFirstName_ShouldThrowMissingParentException_WhenParentIsNotSet()
    {
        // Arrange
        var filter = new ParentFilter();

        // Act & Assert
        Assert.Throws<MissingParentException>(filter.NormalizeFirstName);
    }

    [Fact]
    public void NormalizeFirstName_ShouldNormalizeFirstNameToEmpty_WhenFirstNameIsNull()
    {
        // Arrange
        var parent = Parent.Create(Guid.NewGuid(), null, "Martinez", "David@gmail.com", "12345678mM*", "1234567890");
        var filter = new ParentFilter().Set(parent);

        // Act
        filter.NormalizeFirstName();

        // Assert
        Assert.Equal(string.Empty, parent.FirstName);
    }

    [Fact]
    public void NormalizeFirstName_ShouldNormalizeFirstNameToEmpty_WhenFirstNameIsempty()
    {
        // Arrange
        var parent = Parent.Create(Guid.NewGuid(), "", "Martinez", "David@gmail.com", "12345678mM*", "1234567890");
        var filter = new ParentFilter().Set(parent);

        // Act
        filter.NormalizeFirstName();

        // Assert
        Assert.Equal(string.Empty, parent.FirstName);
    }

    [Fact]
    public void NormalizeFirstName_ShouldNormalizeFirstNameToEmpty_WhenFirstNameIsWhiteSpace()
    {
        // Arrange
        var parent = Parent.Create(Guid.NewGuid(), "   ", "Martinez", "David@gmail.com", "12345678mM*", "1234567890");
        var filter = new ParentFilter().Set(parent);

        // Act
        filter.NormalizeFirstName();

        // Assert
        Assert.Equal(string.Empty, parent.FirstName);
    }
}
