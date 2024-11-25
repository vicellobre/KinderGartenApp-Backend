using KinderGartenApp.Application.Filters;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Exceptions;

namespace KinderGartenApp.Tests.Application.Filters;

public partial class TeacherFilterTests
{
    [Fact]
    public void NormalizeFirstName_ShouldNormalizeFirstName_WhenTeacherIsSet()
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), " john ", "Doe", GradeLevel.Kinder3);
        var filter = new TeacherFilter().Set(teacher);

        // Act
        filter.NormalizeFirstName();

        // Assert
        Assert.Equal("John", teacher.FirstName);
    }

    [Fact]
    public void NormalizeFirstName_ShouldThrowMissingTeacherException_WhenTeacherIsNotSet()
    {
        // Arrange
        var filter = new TeacherFilter();

        // Act & Assert
        Assert.Throws<MissingTeacherException>(filter.NormalizeFirstName);
    }

    [Fact]
    public void NormalizeFirstName_ShouldNormalizeFirstNameToEmpty_WhenFirstNameIsNull()
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), null, "Doe", GradeLevel.PreKinder);
        var filter = new TeacherFilter().Set(teacher);

        // Act
        filter.NormalizeFirstName();

        // Assert
        Assert.Equal(string.Empty, teacher.FirstName);
    }

    [Fact]
    public void NormalizeFirstName_ShouldNormalizeFirstNameToEmpty_WhenFirstNameIsempty()
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), "", "Doe", GradeLevel.PreKinder);
        var filter = new TeacherFilter().Set(teacher);

        // Act
        filter.NormalizeFirstName();

        // Assert
        Assert.Equal(string.Empty, teacher.FirstName);
    }

    [Fact]
    public void NormalizeFirstName_ShouldNormalizeFirstNameToEmpty_WhenFirstNameIsWhiteSpace()
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), "  ", "Doe", GradeLevel.PreKinder);
        var filter = new TeacherFilter().Set(teacher);

        // Act
        filter.NormalizeFirstName();

        // Assert
        Assert.Equal(string.Empty, teacher.FirstName);
    }
}
