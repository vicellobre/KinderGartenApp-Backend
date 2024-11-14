using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Tests.Core.Entities.Teachers;

public partial class TeacherTests
{
    [Fact]
    public void Teacher_GetHashCode_ShouldReturnConsistentHashCode()
    {
        // Arrange
        var id = Guid.NewGuid();
        var teacher = Teacher.Create(id, "Juan", "Perez", GradeLevel.PreKinder);

        // Act
        var hashCode = teacher.GetHashCode();

        // Assert
        Assert.Equal(id.GetHashCode() * 41, hashCode);
    }

    [Fact]
    public void Teacher_GetHashCode_WithDifferentIds_ShouldReturnDifferentHashCodes()
    {
        // Arrange
        var teacher1 = Teacher.Create(Guid.NewGuid(), "Juan", "Perez", GradeLevel.Kinder3);
        var teacher2 = Teacher.Create(Guid.NewGuid(), "Juan", "Perez", GradeLevel.Kinder3);

        // Act
        var hashCode1 = teacher1.GetHashCode();
        var hashCode2 = teacher2.GetHashCode();

        // Assert
        Assert.NotEqual(hashCode1, hashCode2);
    }
}