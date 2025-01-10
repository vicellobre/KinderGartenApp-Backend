using KinderGartenApp.Application.DTOs.Children.AddTeacher;

namespace KinderGartenApp.Tests.Application.DTOs.Children.AddTeacher;

public class AddTeacherResponseTests
{
    [Fact]
    public void AddTeacherResponse_ShouldInitializeProperly()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var studentFirstName = "David";
        var studentLastName = "Martinez";
        var teacherId = Guid.NewGuid();
        var teacherFirstName = "Mateo";
        var teacherLastName = "Quiceno";

        // Act
        var response = new AddTeacherResponse
        {
            TeacherId = teacherId,
            TeacherFirstName = teacherFirstName,
            TeacherLastName = teacherLastName,
            ChildId = studentId,
            ChildFirstName = studentFirstName,
            ChildLastName = studentLastName
        };

        // Assert
        Assert.Equal(studentId, response.ChildId);
        Assert.Equal(studentFirstName, response.ChildFirstName);
        Assert.Equal(studentLastName, response.ChildLastName);
        Assert.Equal(teacherId, response.TeacherId);
        Assert.Equal(teacherFirstName, response.TeacherFirstName);
        Assert.Equal(teacherLastName, response.TeacherLastName);
    }
}
