using KinderGartenApp.Application.DTOs.Children.AddTeacher;

namespace KinderGartenApp.Tests.Application.DTOs.Children.AddTeacher;

public class AddTeacherMessageTests
{
    [Fact]
    public void AddTeacherMessage_ShouldInitializeProperly()
    {
        // Arrange
        var teacherId = Guid.NewGuid();
        var studentId = Guid.NewGuid();

        // Act
        var message = new AddTeacherResponse
        {
            ChildId = teacherId,
            TeacherId = studentId
        };

        // Assert
        Assert.Equal(teacherId, message.ChildId);
        Assert.Equal(studentId, message.TeacherId);
    }
}
