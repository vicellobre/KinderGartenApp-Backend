using KinderGartenApp.Application.Filters;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Tests.Application.Filters;

public partial class ChildFilterTests
{
    [Fact]
    public void Normalize_ShouldNormalizeFirstNameAndLastName()
    {
        // Arrange
        var child = Child.Create(Guid.NewGuid(), "Mateo", "\nÁlvarez", DateTime.Today.AddYears(-6), GradeLevel.PreKinder, new Guid(), new Guid());
        var expectedFirstName = "Mateo";
        var expectedLastName = "Álvarez";

        // Act
        var normalizedChild = ChildFilter.Normalize(child);

        // Assert
        Assert.Equal(expectedFirstName, normalizedChild.FirstName);
        Assert.Equal(expectedLastName, normalizedChild.LastName);
    }

    [Fact]
    public void Normalize_ShouldNormalizeToEmpty_WhenFirstNameIsNull()
    {
        // Arrange
        var child = Child.Create(Guid.NewGuid(), null, "Quiceno", DateTime.Today.AddYears(-6), GradeLevel.PreKinder, new Guid(), new Guid());

        // Act
        var normalizedChild = ChildFilter.Normalize(child);

        // Assert
        Assert.Equal(string.Empty, normalizedChild.FirstName);
        Assert.Equal("Quiceno", normalizedChild.LastName);
    }

    [Fact]
    public void Normalize_ShouldNormalizeToEmpty_WhenLastNameIsNull()
    {
        // Arrange
        var child = Child.Create(Guid.NewGuid(), " Mateo", null, DateTime.Today.AddYears(-6), GradeLevel.PreKinder, new Guid(), new Guid());

        // Act
        var normalizedChild = ChildFilter.Normalize(child);

        // Assert
        Assert.Equal("Mateo", normalizedChild.FirstName);
        Assert.Equal(string.Empty, normalizedChild.LastName);
    }

    [Fact]
    public void Normalize_ShouldThrowArgumentNullException_WhenChildIsNull()
    {
        // Arrange
        Child? child = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => ChildFilter.Normalize(child));
    }
}
