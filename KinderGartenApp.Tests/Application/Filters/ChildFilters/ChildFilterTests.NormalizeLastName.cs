using KinderGartenApp.Application.Filters;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Exceptions;

namespace KinderGartenApp.Tests.Application.Filters;

public partial class ChildFilterTests
{
    [Fact]
    public void NormalizeLastName_ShouldNormalizeLastName_WhenChildIsSet()
    {
        // Arrange
        var child = Child.Create(Guid.NewGuid(), "Mateo", " quiceno", DateTime.Today.AddYears(-6), GradeLevel.PreKinder, new Guid(), new Guid());
        var filter = new ChildFilter().Set(child);

        // Act
        filter.NormalizeLastName();

        // Assert
        Assert.Equal("Quiceno", child.LastName);
    }

    [Fact]
    public void NormalizeLastName_ShouldNormalizeLastNameToEmpty_WhenLastNameIsNull()
    {
        // Arrange
        var child = Child.Create(Guid.NewGuid(), "Mateo", null, DateTime.Today.AddYears(-6), GradeLevel.PreKinder, new Guid(), new Guid());
        var filter = new ChildFilter().Set(child);

        // Act
        filter.NormalizeLastName();

        // Assert
        Assert.Equal(string.Empty, child.LastName);
    }

    [Fact]
    public void NormalizeLastName_ShouldNormalizeLastNameToEmpty_WhenLastNameIsEmpty()
    {
        // Arrange
        var child = Child.Create(Guid.NewGuid(), "Mateo", "", DateTime.Today.AddYears(-6), GradeLevel.PreKinder, new Guid(), new Guid());
        var filter = new ChildFilter().Set(child);

        // Act
        filter.NormalizeLastName();

        // Assert
        Assert.Equal(string.Empty, child.LastName);
    }

    [Fact]
    public void NormalizeLastName_ShouldNormalizeLastNameToEmpty_WhenLastNameIsWhiteSpace()
    {
        // Arrange
        var child = Child.Create(Guid.NewGuid(), "Mateo", "  ", DateTime.Today.AddYears(-6), GradeLevel.PreKinder, new Guid(), new Guid());
        var filter = new ChildFilter().Set(child);

        // Act
        filter.NormalizeLastName();

        // Assert
        Assert.Equal(string.Empty, child.LastName);
    }

    [Fact]
    public void NormalizeLastName_ShouldThrowMissingChildException_WhenChildIsNotSet()
    {
        // Arrange
        var filter = new ChildFilter();

        // Act & Assert
        Assert.Throws<MissingChildException>(filter.NormalizeLastName);
    }
}
