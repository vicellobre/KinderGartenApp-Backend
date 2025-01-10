using KinderGartenApp.Application.DTOs.Children.Update;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Errors;

namespace KinderGartenApp.Tests.Application.DTOs.Children.Updates;

public class UpdateStudentMessageTests
{
    [Fact]
    public void ExplicitConversion_ShouldConvertToStudent_WhenMessageIsValid()
    {
        // Arrange
        var message = new UpdateChildMessage
        {
            Id = Guid.NewGuid(),
            FirstName = "David",
            LastName = "Martinez",
            GradeLevel = GradeLevel.PreKinder
        };

        // Act
        var student = (Child?)message;

        // Assert
        Assert.NotNull(student);
        Assert.Equal(message.Id, student.Id);
        Assert.Equal(message.FirstName, student.FirstName);
        Assert.Equal(message.LastName, student.LastName);
        Assert.Equal(message.GradeLevel, student.GradeLevel);
    }

    [Fact]
    public void ExplicitConversion_ShouldThrowArgumentNullException_WhenMessageIsNull()
    {
        // Arrange
        UpdateChildMessage? message = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => (Child?)message);
        Assert.Contains(Error.ChildRequest.UpdateIsNull.Message, exception.Message);
    }
}
