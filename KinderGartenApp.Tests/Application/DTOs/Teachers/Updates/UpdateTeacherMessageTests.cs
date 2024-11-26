using KinderGartenApp.Application.DTOs.Teachers.Update;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Errors;

namespace KinderGartenApp.Tests.Application.DTOs.Teachers.Updates;

public class UpdateTeacherMessageTests
{
    [Fact]
    public void ExplicitConversion_ShouldConvertToTeacher_WhenMessageIsValid()
    {
        // Arrange
        var message = new UpdateTeacherMessage
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            GradeLevel = GradeLevel.PreKinder
        };

        // Act
        var teacher = (Teacher?)message;

        // Assert
        Assert.NotNull(teacher);
        Assert.Equal(message.Id, teacher.Id);
        Assert.Equal(message.FirstName, teacher.FirstName);
        Assert.Equal(message.LastName, teacher.LastName);
        Assert.Equal(message.GradeLevel, teacher.GradeLevel);
    }

    [Fact]
    public void ExplicitConversion_ShouldThrowArgumentNullException_WhenMessageIsNull()
    {
        // Arrange
        UpdateTeacherMessage? message = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => (Teacher?)message);
        Assert.Contains(Error.TeacherRequest.UpdateIsNull.Message, exception.Message);
    }
}
