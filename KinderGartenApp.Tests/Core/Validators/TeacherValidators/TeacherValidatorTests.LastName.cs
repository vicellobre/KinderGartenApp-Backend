using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Validators;

namespace KinderGartenApp.Tests.Core.Validators.TeacherValidators;

public partial class TeacherValidatorTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Validate_InvalidLastName_ReturnsFalse(string? lastName)
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), "Juan", lastName, GradeLevel.PreKinder);

        // Act
        var result = TeacherValidator.Validate(teacher);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("InvalidLastName@")]
    [InlineData("Pérez123")]
    public void Validate_InvalidLastNameWithSpecialCharacters_ReturnsFalse(string lastName)
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), "Juan", lastName, GradeLevel.Kinder1);

        // Act
        var result = TeacherValidator.Validate(teacher);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("ThisIsAVeryLongLastNameThatExceedsThirtyCharacters")]
    public void Validate_LastNameTooLong_ReturnsFalse(string lastName)
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), "Juan", lastName, GradeLevel.Kinder2);

        // Act
        var result = TeacherValidator.Validate(teacher);

        // Assert
        Assert.False(result);
    }
}

