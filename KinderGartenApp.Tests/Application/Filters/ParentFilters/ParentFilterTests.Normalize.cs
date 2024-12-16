using KinderGartenApp.Application.Filters;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Tests.Application.Filters;

public partial class ParentFilterTests
{
    [Fact]
    public void Normalize_ShouldNormalizeFirstNameAndLastName()
    {
        // Arrange
        var parent = Parent.Create(Guid.NewGuid(), "David", "martinez\n", "David@gmail.com", "12345678mM*", "1234567890");
        var expectedFirstName = "David";
        var expectedLastName = "Martinez";

        // Act
        var normalizedParent = ParentFilter.Normalize(parent);

        // Assert
        Assert.Equal(expectedFirstName, normalizedParent.FirstName);
        Assert.Equal(expectedLastName, normalizedParent.LastName);
    }

    [Fact]
    public void Normalize_ShouldNormalizeToEmpty_WhenFirstNameIsNull()
    {
        // Arrange
        var parent = Parent.Create(Guid.NewGuid(), null, "Martinez", "David@gmail.com", "12345678mM*", "1234567890");

        // Act
        var normalizedParent = ParentFilter.Normalize(parent);

        // Assert
        Assert.Equal(string.Empty, normalizedParent.FirstName);
        Assert.Equal("Martinez", normalizedParent.LastName);
    }

    [Fact]
    public void Normalize_ShouldNormalizeToEmpty_WhenLastNameIsNull()
    {
        // Arrange
        var parent = Parent.Create(Guid.NewGuid(), " David", null, "David@gmail.com", "12345678mM*", "1234567890");

        // Act
        var normalizedParent = ParentFilter.Normalize(parent);

        // Assert
        Assert.Equal("David", normalizedParent.FirstName);
        Assert.Equal(string.Empty, normalizedParent.LastName);
    }

    [Fact]
    public void Normalize_ShouldThrowArgumentNullException_WhenParentIsNull()
    {
        // Arrange
        Parent? parent = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => ParentFilter.Normalize(parent));
    }
}
