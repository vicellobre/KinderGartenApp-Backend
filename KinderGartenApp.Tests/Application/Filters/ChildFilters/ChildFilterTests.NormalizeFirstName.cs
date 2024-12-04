using KinderGartenApp.Application.Filters;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Exceptions;

namespace KinderGartenApp.Tests.Application.Filters;

public partial class ChildFilterTests
{
    [Fact]
    public void NormalizeFirstName_ShouldNormalizeFirstName_WhenChildIsSet()
    {
        // Arrange
        var child = Child.Create(Guid.NewGuid(), " mateo", "Quiceno", DateTime.Today.AddYears(-6), GradeLevel.PreKinder, new Guid(), new Guid());
        var filter = new ChildFilter().Set(child);

        // Act
        filter.NormalizeFirstName();

        // Assert
        Assert.Equal("Mateo", child.FirstName);
    }

    [Fact]
    public void NormalizeFirstName_ShouldThrowMissingChildException_WhenChildIsNotSet()
    {
        // Arrange
        var filter = new ChildFilter();

        // Act & Assert
        Assert.Throws<MissingChildException>(filter.NormalizeFirstName);
    }

    [Fact]
    public void NormalizeFirstName_ShouldNormalizeFirstNameToEmpty_WhenFirstNameIsNull()
    {
        // Arrange
        var child = Child.Create(Guid.NewGuid(), null, "Quiceno", DateTime.Today.AddYears(-6), GradeLevel.PreKinder, new Guid(), new Guid());
        var filter = new ChildFilter().Set(child);

        // Act
        filter.NormalizeFirstName();

        // Assert
        Assert.Equal(string.Empty, child.FirstName);
    }

    [Fact]
    public void NormalizeFirstName_ShouldNormalizeFirstNameToEmpty_WhenFirstNameIsempty()
    {
        // Arrange
        var child = Child.Create(Guid.NewGuid(), "", "Quiceno", DateTime.Today.AddYears(-6), GradeLevel.PreKinder, new Guid(), new Guid());
        var filter = new ChildFilter().Set(child);

        // Act
        filter.NormalizeFirstName();

        // Assert
        Assert.Equal(string.Empty, child.FirstName);
    }

    [Fact]
    public void NormalizeFirstName_ShouldNormalizeFirstNameToEmpty_WhenFirstNameIsWhiteSpace()
    {
        // Arrange
        var child = Child.Create(Guid.NewGuid(), "  ", "Quiceno", DateTime.Today.AddYears(-6), GradeLevel.PreKinder, new Guid(), new Guid());
        var filter = new ChildFilter().Set(child);

        // Act
        filter.NormalizeFirstName();

        // Assert
        Assert.Equal(string.Empty, child.FirstName);
    }
}
