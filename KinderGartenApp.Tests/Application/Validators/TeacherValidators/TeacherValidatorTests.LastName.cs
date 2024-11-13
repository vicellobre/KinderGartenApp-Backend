﻿using KinderGartenApp.Application.Validators;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Tests.Application.Validators.TeacherValidators;

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
        Assert.False(result.IsSuccess);
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
        Assert.False(result.IsSuccess);
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
        Assert.False(result.IsSuccess);
    }
}

