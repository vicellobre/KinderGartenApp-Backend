using KinderGartenApp.Application.DTOs.Teachers.Register;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Tests.Application.DTOs.Teachers.Registers;

public class RegisterTeacherMessageTests
{
    [Fact]
    public void ExplicitConversion_ShouldConvertToTeacher_WhenMessageIsValid()
    {
        // Arrange
        var message = new RegisterTeacherMessage
        {
            FirstName = "John",
            LastName = "Doe",
            GradeLevel = GradeLevel.PreKinder
        };

        // Act
        var teacher = (Teacher)message;

        // Assert
        Assert.NotNull(teacher);
        Assert.Equal(message.FirstName, teacher.FirstName);
        Assert.Equal(message.LastName, teacher.LastName);
        Assert.Equal(message.GradeLevel, teacher.GradeLevel);
    }

    [Fact]
    public void ExplicitConversion_ShouldThrowArgumentNullException_WhenMessageIsNull()
    {
        // Arrange
        RegisterTeacherMessage? message = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => (Teacher)message!);
        Assert.Equal("RegisterTeacherMessage cannot be null (Parameter 'teacher')", exception.Message);
    }
}
