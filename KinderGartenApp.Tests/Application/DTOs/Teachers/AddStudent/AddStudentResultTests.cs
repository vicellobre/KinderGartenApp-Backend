using KinderGartenApp.Application.DTOs.Teachers.AddStudent;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Errors;

namespace KinderGartenApp.Tests.Application.DTOs.Teachers.AddStudent;

public class AddStudentResultTests
{
    [Fact]
    public void AddStudentResult_ShouldInitializeProperly()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var studentFirstName = "Alice";
        var studentLastName = "Johnson";
        var teacherId = Guid.NewGuid();
        var teacherFirstName = "John";
        var teacherLastName = "Doe";

        // Act
        var response = new AddStudentResult
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

    [Fact]
    public void CreateFrom_ShouldReturnValidAddStudentResult()
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), "John", "Doe", GradeLevel.PreKinder);

        var student = Child.Create(
            Guid.NewGuid(),
            "Jane",
            "Smith",
            new DateTime(2010, 1, 1),
            GradeLevel.PreKinder,
            Guid.NewGuid(),
            teacher.Id
        );

        // Act
        var result = AddStudentResult.CreateFrom(teacher, student);

        // Assert
        Assert.Equal(student.Id, result.StudentId);
        Assert.Equal(student.FirstName, result.StudentFirstName);
        Assert.Equal(student.LastName, result.StudentLastName);
        Assert.Equal(teacher.Id, result.TeacherId);
        Assert.Equal(teacher.FirstName, result.TeacherFirstName);
        Assert.Equal(teacher.LastName, result.TeacherLastName);
    }

    [Fact]
    public void CreateFrom_ShouldThrowArgumentNullException_WhenTeacherIsNull()
    {
        // Arrange
        Teacher? teacher = null;

        var student = Child.Create(
            Guid.NewGuid(),
            "Jane",
            "Smith",
            new DateTime(2010, 1, 1),
            GradeLevel.Kinder3,
            Guid.NewGuid(),
            Guid.NewGuid()
        );

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => AddStudentResult.CreateFrom(teacher, student));
        Assert.Equal(nameof(teacher), exception.ParamName);
        Assert.Equal(Error.Teacher.IsNull.Message + " (Parameter 'teacher')", exception.Message);
    }

    [Fact]
    public void CreateFrom_ShouldThrowArgumentNullException_WhenStudentIsNull()
    {
        // Arrange
        Teacher teacher = Teacher.Create(Guid.NewGuid(), "John", "Doe", GradeLevel.Kinder3);
        Child? student = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => AddStudentResult.CreateFrom(teacher, student));
        Assert.Equal(nameof(student), exception.ParamName);
        Assert.Equal(Error.Child.IsNull.Message + " (Parameter 'student')", exception.Message);
    }
}