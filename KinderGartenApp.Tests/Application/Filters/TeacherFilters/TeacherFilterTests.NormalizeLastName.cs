using KinderGartenApp.Application.Filters;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Exceptions;

namespace KinderGartenApp.Tests.Application.Filters;

public partial class TeacherFilterTests
{
    [Fact]
    public void NormalizeLastName_ShouldNormalizeLastName_WhenTeacherIsSet()
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), "John", " doe ", GradeLevel.Kinder1);
        var filter = new TeacherFilter().Set(teacher);

        // Act
        filter.NormalizeLastName();

        // Assert
        Assert.Equal("Doe", teacher.LastName);
    }

    [Fact]
    public void NormalizeLastName_ShouldNormalizeLastNameToEmpty_WhenLastNameIsNull()
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), "John", null, GradeLevel.Kinder2);
        var filter = new TeacherFilter().Set(teacher);

        // Act
        filter.NormalizeLastName();

        // Assert
        Assert.Equal(string.Empty, teacher.LastName);
    }

    [Fact]
    public void NormalizeLastName_ShouldNormalizeLastNameToEmpty_WhenLastNameIsEmpty()
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), "John", "", GradeLevel.Kinder2);
        var filter = new TeacherFilter().Set(teacher);

        // Act
        filter.NormalizeLastName();

        // Assert
        Assert.Equal(string.Empty, teacher.LastName);
    }

    [Fact]
    public void NormalizeLastName_ShouldNormalizeLastNameToEmpty_WhenLastNameIsWhiteSpace()
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), "John", " ", GradeLevel.Kinder2);
        var filter = new TeacherFilter().Set(teacher);

        // Act
        filter.NormalizeLastName();

        // Assert
        Assert.Equal(string.Empty, teacher.LastName);
    }

    [Fact]
    public void NormalizeLastName_ShouldThrowMissingTeacherException_WhenTeacherIsNotSet()
    {
        // Arrange
        var filter = new TeacherFilter();

        // Act & Assert
        Assert.Throws<MissingTeacherException>(filter.NormalizeLastName);
    }
}
