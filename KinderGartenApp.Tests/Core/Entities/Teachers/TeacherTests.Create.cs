using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Entities;

namespace KinderGartenApp.Tests.Core.Entities.Teachers;

public partial class TeacherTests
{
    [Fact]
    public void Teacher_Create_WithValidData_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        var id = Guid.NewGuid();
        var firstName = "Juan";
        var lastName = "Pérez";
        var gradeLevel = GradeLevel.PreKinder;

        // Act
        var teacher = Teacher.Create(id, firstName, lastName, gradeLevel);

        // Assert
        Assert.Equal(id, teacher.Id);
        Assert.Equal(firstName, teacher.FirstName);
        Assert.Equal(lastName, teacher.LastName);
        Assert.Equal(gradeLevel, teacher.GradeLevel);
    }

    [Fact]
    public void Teacher_Create_WithNullFirstName_ShouldAllowCreation()
    {
        // Arrange
        var id = Guid.NewGuid();
        string? firstName = null;
        var lastName = "Perez";
        var gradeLevel = GradeLevel.PreKinder;

        // Act
        var teacher = Teacher.Create(id, firstName, lastName, gradeLevel);

        // Assert
        Assert.Null(teacher.FirstName);
        Assert.Equal(lastName, teacher.LastName);
        Assert.Equal(gradeLevel, teacher.GradeLevel);
    }

    [Fact]
    public void Teacher_Create_WithNullLastName_ShouldAllowCreation()
    {
        // Arrange
        var id = Guid.NewGuid();
        var firstName = "Juan";
        string? lastName = null;
        var gradeLevel = GradeLevel.PreKinder;

        // Act
        var teacher = Teacher.Create(id, firstName, lastName, gradeLevel);

        // Assert
        Assert.Equal(firstName, teacher.FirstName);
        Assert.Null(teacher.LastName);
        Assert.Equal(gradeLevel, teacher.GradeLevel);
    }

    [Fact]
    public void Teacher_Create_WithInvalidGradeLevel_ShouldSetGradeLevelToInvalidValue()
    {
        // Arrange
        var id = Guid.NewGuid();
        var firstName = "Juan";
        var lastName = "Pérez";
        var invalidGradeLevel = (GradeLevel)100; // Invalid grade level

        // Act
        var teacher = Teacher.Create(id, firstName, lastName, invalidGradeLevel);

        // Assert
        Assert.NotNull(teacher);
        Assert.Equal(invalidGradeLevel, teacher.GradeLevel);
    }

}