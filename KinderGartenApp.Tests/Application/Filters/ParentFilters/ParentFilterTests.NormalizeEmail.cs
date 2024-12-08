using KinderGartenApp.Application.Filters;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Exceptions;

namespace KinderGartenApp.Tests.Application.Filters;

public partial class ParentFilterTests
{
    [Fact]
    public void NormalizeEmail_ShouldNormalizeEmail_WhenParentIsSet()
    {
        // Arrange
        var parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", " David@gmail.com", "12345678mM*", "1234567890");
        var filter = new ParentFilter().Set(parent);

        // Act
        filter.NormalizeEmail();

        // Assert
        Assert.Equal("david@gmail.com", parent.Email);
    }

    [Fact]
    public void NormalizeEmail_ShouldNormalizeEmail_WhenParentIsSetAndEmailIsAllUpperCase()
    {
        // Arrange
        var parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "DAVID@GMAIL.COM ", "12345678mM*", "1234567890");
        var filter = new ParentFilter().Set(parent);

        // Act
        filter.NormalizeEmail();

        // Assert
        Assert.Equal("david@gmail.com", parent.Email);
    }

    [Fact]
    public void NormalizeEmail_ShouldNormalizeEmailToEmpty_WhenEmailIsNull()
    {
        // Arrange
        var parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", null, "12345678mM*", "1234567890");
        var filter = new ParentFilter().Set(parent);

        // Act
        filter.NormalizeEmail();

        // Assert
        Assert.Equal(string.Empty, parent.Email);
    }

    [Fact]
    public void NormalizeEmail_ShouldNormalizeEmailToEmpty_WhenEmailIsEmpty()
    {
        // Arrange
        var parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "", "12345678mM*", "1234567890");
        var filter = new ParentFilter().Set(parent);

        // Act
        filter.NormalizeEmail();

        // Assert
        Assert.Equal(string.Empty, parent.Email);
    }

    [Fact]
    public void NormalizeEmail_ShouldNormalizeEmailToEmpty_WhenEmailIsWhiteSpace()
    {
        // Arrange
        var parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "   ", "12345678mM*", "1234567890");
        var filter = new ParentFilter().Set(parent);

        // Act
        filter.NormalizeEmail();

        // Assert
        Assert.Equal(string.Empty, parent.Email);
    }

    [Fact]
    public void NormalizeEmail_ShouldThrowMissingParentException_WhenParentIsNotSet()
    {
        // Arrange
        var filter = new ParentFilter();

        // Act & Assert
        Assert.Throws<MissingParentException>(filter.NormalizeEmail);
    }
}
