using KinderGartenApp.Application.Filters;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Exceptions;

namespace KinderGartenApp.Tests.Application.Filters;

public partial class TeacherFilterTests
{
    [Fact]
    public void Get_ShouldReturnTeacher_WhenTeacherIsSet()
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), "John", "Doe", GradeLevel.Kinder3);
        var filter = new TeacherFilter().Set(teacher);

        // Act
        var result = filter.Get();

        // Assert
        Assert.Equal(teacher, result);
    }

    [Fact]
    public void Get_ShouldThrowMissingTeacherException_WhenTeacherIsNotSet()
    {
        // Arrange
        var filter = new TeacherFilter();

        // Act & Assert
        Assert.Throws<MissingTeacherException>(filter.Get);
    }

    [Fact]
    public void Set_ShouldThrowArgumentNullException_WhenTeacherIsNull()
    {
        Teacher? teacher = null;

        // Arrange
        var filter = new TeacherFilter();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => filter.Set(teacher!));
    }
}
