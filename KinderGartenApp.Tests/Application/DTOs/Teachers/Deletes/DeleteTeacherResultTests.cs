﻿using KinderGartenApp.Application.DTOs.Teachers.Deletes;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Tests.Application.DTOs.Teachers.Deletes;

public class DeleteTeacherResultTests
{
    [Fact]
    public void DeleteTeacherResult_ShouldInitializeProperly()
    {
        // Arrange
        var id = Guid.NewGuid();
        var firstName = "John";
        var lastName = "Doe";

        // Act
        var response = new DeleteTeacherResult
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName
        };

        // Assert
        Assert.Equal(id, response.Id);
        Assert.Equal(firstName, response.FirstName);
        Assert.Equal(lastName, response.LastName);
    }

    [Fact]
    public void ExplicitConversion_ShouldConvertToDeleteTeacherResult_WhenTeacherIsValid()
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), "John", "Doe", GradeLevel.PreKinder);

        // Act
        var response = (DeleteTeacherResult)teacher;

        // Assert
        Assert.NotNull(response);
        Assert.Equal(teacher.Id, response.Id);
        Assert.Equal(teacher.FirstName, response.FirstName);
        Assert.Equal(teacher.LastName, response.LastName);
    }

    [Fact]
    public void ExplicitConversion_ShouldThrowArgumentNullException_WhenTeacherIsNull()
    {
        // Arrange
        Teacher? teacher = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => (DeleteTeacherResult)teacher);
        Assert.Equal("Teacher cannot be null (Parameter 'teacher')", exception.Message);
    }
}