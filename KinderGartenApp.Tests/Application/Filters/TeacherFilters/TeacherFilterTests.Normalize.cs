using KinderGartenApp.Application.Filters;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Tests.Application.Filters;

public partial class TeacherFilterTests
{
    [Fact]
    public void Normalize_ShouldNormalizeFirstNameAndLastName()
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), " maría  josÉ\n", " PÉREZ ", GradeLevel.Kinder2);
        var expectedFirstName = "María José";
        var expectedLastName = "Pérez";

        // Act
        var normalizedTeacher = TeacherFilter.Normalize(teacher);

        // Assert
        Assert.Equal(expectedFirstName, normalizedTeacher.FirstName);
        Assert.Equal(expectedLastName, normalizedTeacher.LastName);
    }

    [Fact]
    public void Normalize_ShouldNormalizeToEmpty_WhenFirstNameIsNull()
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), null, " DOE ", GradeLevel.Kinder2);

        // Act
        var normalizedTeacher = TeacherFilter.Normalize(teacher);

        // Assert
        Assert.Equal(string.Empty, normalizedTeacher.FirstName);
        Assert.Equal("Doe", normalizedTeacher.LastName);
    }

    [Fact]
    public void Normalize_ShouldNormalizeToEmpty_WhenLastNameIsNull()
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), " john ", null, GradeLevel.Kinder2);

        // Act
        var normalizedTeacher = TeacherFilter.Normalize(teacher);

        // Assert
        Assert.Equal("John", normalizedTeacher.FirstName);
        Assert.Equal(string.Empty, normalizedTeacher.LastName);
    }

    [Fact]
    public void Normalize_ShouldThrowArgumentNullException_WhenTeacherIsNull()
    {
        // Arrange
        Teacher? teacher = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => TeacherFilter.Normalize(teacher));
    }
}
