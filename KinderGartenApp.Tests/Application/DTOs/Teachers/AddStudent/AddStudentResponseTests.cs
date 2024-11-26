using KinderGartenApp.Application.DTOs.Teachers.AddStudent;

namespace KinderGartenApp.Tests.Application.DTOs.Teachers.AddStudent;

public class AddStudentResponseTests
{
    [Fact]
    public void AddStudentResponse_ShouldInitializeProperly()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var studentFirstName = "Alice";
        var studentLastName = "Johnson";
        var teacherId = Guid.NewGuid();
        var teacherFirstName = "John";
        var teacherLastName = "Doe";

        // Act
        var response = new AddStudentResponse
        {
            StudentId = studentId,
            StudentFirstName = studentFirstName,
            StudentLastName = studentLastName,
            TeacherId = teacherId,
            TeacherFirstName = teacherFirstName,
            TeacherLastName = teacherLastName
        };

        // Assert
        Assert.Equal(studentId, response.StudentId);
        Assert.Equal(studentFirstName, response.StudentFirstName);
        Assert.Equal(studentLastName, response.StudentLastName);
        Assert.Equal(teacherId, response.TeacherId);
        Assert.Equal(teacherFirstName, response.TeacherFirstName);
        Assert.Equal(teacherLastName, response.TeacherLastName);
    }
}
