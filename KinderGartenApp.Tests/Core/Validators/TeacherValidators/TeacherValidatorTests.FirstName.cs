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
    public void Validate_InvalidFirstName_ReturnsFalse(string? firstName)
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), firstName, "Pérez", GradeLevel.PreKinder);

        // Act
        var result = TeacherValidator.Validate(teacher);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("InvalidName@")]
    [InlineData("Juan123")]
    public void Validate_InvalidFirstNameWithSpecialCharacters_ReturnsFalse(string firstName)
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), firstName, "Pérez", GradeLevel.Kinder1);

        // Act
        var result = TeacherValidator.Validate(teacher);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("ThisIsAVeryLongNameThatExceedsThirtyCharacters")]
    public void Validate_FirstNameTooLong_ReturnsFalse(string firstName)
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), firstName, "Pérez", GradeLevel.Kinder2);

        // Act
        var result = TeacherValidator.Validate(teacher);

        // Assert
        Assert.False(result);
    }
}