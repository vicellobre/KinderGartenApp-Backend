using KinderGartenApp.Application.DTOs.Children.Register;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Errors;

namespace KinderGartenApp.Tests.Application.DTOs.Children.Registers;

public class RegisterStudentMessageTests
{
    [Fact]
    public void ExplicitConversion_ShouldConvertToStudent_WhenMessageIsValid()
    {
        // Arrange
        var message = new RegisterChildMessage
        {
            FirstName = "Daved",
            LastName = "Martinez",
            GradeLevel = GradeLevel.PreKinder
        };

        // Act
        var student = (Child?)message;

        // Assert
        Assert.NotNull(student);
        Assert.Equal(message.FirstName, student.FirstName);
        Assert.Equal(message.LastName, student.LastName);
        Assert.Equal(message.GradeLevel, student.GradeLevel);
    }

    [Fact]
    public void ExplicitConversion_ShouldThrowArgumentNullException_WhenMessageIsNull()
    {
        // Arrange
        RegisterChildMessage? message = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => (Child?)message);
        Assert.Contains(Error.ChildRequest.RegisterIsNull.Message, exception.Message);
    }
}
