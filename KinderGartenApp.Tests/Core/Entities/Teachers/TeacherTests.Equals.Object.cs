using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Tests.Core.Entities.Teachers;

public partial class TeacherTests
{
    [Fact]
    public void Teacher_EqualsObject_ShouldReturnTrueForSameId()
    {
        // Arrange
        var id = Guid.NewGuid();
        Teacher teacher1 = Teacher.Create(id, "Maria", "López", GradeLevel.Kinder1);
        object? teacher2 = Teacher.Create(id, "Juan", "Herrera", GradeLevel.Kinder2);

        // Act
        bool result = teacher1.Equals(teacher2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Teacher_EqualsObject_ShouldReturnFalseForDifferentId()
    {
        // Arrange
        Teacher teacher1 = Teacher.Create(Guid.NewGuid(), "Ana", "Ramos", GradeLevel.Kinder3);
        object? teacher2 = Teacher.Create(Guid.NewGuid(), "Ana", "Ramos", GradeLevel.Kinder3);

        // Act
        bool result = teacher1.Equals(teacher2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Teacher_EqualsObject_WithNullObject_ShouldReturnFalse()
    {
        // Arrange
        Teacher teacher1 = Teacher.Create(Guid.NewGuid(), "Juan", "Perez", GradeLevel.Kinder1);
        object? teacher2 = null;

        // Act
        var result = teacher1.Equals(teacher2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Teacher_EqualsObject_WithDifferentType_ShouldReturnFalse()
    {
        // Arrange
        Teacher teacher1 = Teacher.Create(Guid.NewGuid(), "Juan", "Perez", GradeLevel.Kinder2);
        object? teacher2 = new();

        // Act
        var result = teacher1.Equals(teacher2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Teacher_EqualsObject_WithDifferentObject_ShouldReturnFalse()
    {
        // Arrange
        Teacher teacher1 = Teacher.Create(Guid.NewGuid(), "Juan", "Perez", GradeLevel.Kinder2);
        object? teacher2 = Parent.Create(Guid.NewGuid(), "Carlos", "Herrera", "carlos@email.com", "12345678mM*", "+012225454");

        // Act
        var result = teacher1.Equals(teacher2);

        // Assert
        Assert.False(result);
    }
}
