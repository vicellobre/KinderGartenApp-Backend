using KinderGartenApp.Application.Filters;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Exceptions;

namespace KinderGartenApp.Tests.Application.Filters;

public partial class ChildFilterTests
{
    [Fact]
    public void Get_ShouldReturnChild_WhenChildIsSet()
    {
        // Arrange
        var child = Child.Create(Guid.NewGuid(), "Mateo", "Quiceno", DateTime.Today.AddYears(-6), GradeLevel.PreKinder, new Guid(), new Guid());
        var filter = new ChildFilter().Set(child);

        // Act
        var result = filter.Get();

        // Assert
        Assert.Equal(child, result);
    }

    [Fact]
    public void Get_ShouldThrowMissingChildException_WhenChildIsNotSet()
    {
        // Arrange
        var filter = new ChildFilter();

        // Act & Assert
        Assert.Throws<MissingChildException>(filter.Get);
    }

    [Fact]
    public void Set_ShouldThrowArgumentNullException_WhenChildIsNull()
    {
        Child? child = null;

        // Arrange
        var filter = new ChildFilter();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => filter.Set(child!));
    }
}
