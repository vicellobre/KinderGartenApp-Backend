using KinderGartenApp.Application.DTOs.Teachers.Register;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Tests.Application.DTOs.Teachers.Registers;

public class RegisterTeacherResponseTests
{
    [Fact]
    public void ExplicitConversion_ShouldConvertToRegisterTeacherResponse_WhenTeacherIsValid()
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), "John", "Doe", GradeLevel.Kinder1);

        // Act
        var response = (RegisterTeacherResponse)teacher;

        // Assert
        Assert.NotNull(response);
        Assert.Equal(teacher.Id, response.Id);
        Assert.Equal(teacher.FirstName, response.FirstName);
        Assert.Equal(teacher.LastName, response.LastName);
        Assert.Equal(teacher.GradeLevel, response.GradeLevel);
    }

    [Fact]
    public void ExplicitConversion_ShouldThrowArgumentNullException_WhenTeacherIsNull()
    {
        // Arrange
        Teacher? teacher = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => (RegisterTeacherResponse)teacher!);
        Assert.Equal("Teacher cannot be null (Parameter 'teacher')", exception.Message);
    }
}
