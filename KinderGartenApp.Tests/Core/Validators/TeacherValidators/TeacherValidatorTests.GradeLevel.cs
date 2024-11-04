using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Validators;

namespace KinderGartenApp.Tests.Core.Validators.TeacherValidators;

public partial class TeacherValidatorTests
{
    [Theory]
    [InlineData(GradeLevel.PreKinder)]
    [InlineData(GradeLevel.Kinder1)]
    [InlineData(GradeLevel.Kinder2)]
    [InlineData(GradeLevel.Kinder3)]
    public void Validate_ValidGradeLevel_ReturnsTrue(GradeLevel gradeLevel)
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), "Juan", "Pérez", gradeLevel);

        // Act
        var result = TeacherValidator.Validate(teacher);

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData((GradeLevel)100)] // Invalid value outside the defined enumeration
    [InlineData((GradeLevel)(-1))] // Negative invalid value
    public void Validate_InvalidGradeLevel_ReturnsFalse(GradeLevel gradeLevel)
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), "Juan", "Pérez", gradeLevel);

        // Act
        var result = TeacherValidator.Validate(teacher);

        // Assert
        Assert.False(result);
    }
}