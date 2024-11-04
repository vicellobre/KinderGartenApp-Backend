using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Tests.Core.Entities.Teachers;

public partial class TeacherTests
{
    [Fact]
    public void Teacher_Equals_ShouldReturnTrueForSameId()
    {
        // Arrange
        var id = Guid.NewGuid();
        var teacher1 = Teacher.Create(id, "Maria", "López", GradeLevel.Kinder1);
        var teacher2 = Teacher.Create(id, "Juan", "Herrera", GradeLevel.Kinder2);

        // Act & Assert
        Assert.True(teacher1.Equals(teacher2));
    }

    [Fact]
    public void Teacher_Equals_ShouldReturnFalseForDifferentId()
    {
        // Arrange
        var teacher1 = Teacher.Create(Guid.NewGuid(), "Ana", "Ramos", GradeLevel.Kinder3);
        var teacher2 = Teacher.Create(Guid.NewGuid(), "Ana", "Ramos", GradeLevel.Kinder3);

        // Act & Assert
        Assert.False(teacher1.Equals(teacher2));
    }

    [Fact]
    public void Equals_WithNullEntity_ShouldReturnFalse()
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), "Juan", "Perez", GradeLevel.Kinder1);

        // Act
        var result = teacher.Equals(null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Equals_WithDifferentType_ShouldReturnFalse()
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), "Juan", "Perez", GradeLevel.Kinder2);

        // Act
        var result = teacher.Equals(new object());

        // Assert
        Assert.False(result);
    }
}