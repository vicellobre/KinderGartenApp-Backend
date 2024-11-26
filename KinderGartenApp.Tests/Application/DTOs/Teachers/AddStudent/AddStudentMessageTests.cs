using KinderGartenApp.Application.DTOs.Teachers.AddStudent;

namespace KinderGartenApp.Tests.Application.DTOs.Teachers.AddStudent;

public class AddStudentMessageTests
{
    [Fact]
    public void AddStudentMessage_ShouldInitializeProperly()
    {
        // Arrange
        var teacherId = Guid.NewGuid();
        var studentId = Guid.NewGuid();

        // Act
        var message = new AddStudentMessage
        {
            TeacherId = teacherId,
            StudentId = studentId
        };

        // Assert
        Assert.Equal(teacherId, message.TeacherId);
        Assert.Equal(studentId, message.StudentId);
    }
}
