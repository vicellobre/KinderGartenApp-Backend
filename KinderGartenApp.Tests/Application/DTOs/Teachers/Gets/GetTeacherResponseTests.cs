using KinderGartenApp.Application.DTOs.Teachers.Get;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Tests.Application.DTOs.Teachers.Gets;

public class GetTeacherResponseTests
{
    [Fact]
    public void ExplicitConversion_ShouldConvertToGetTeacherResponse_WhenTeacherIsValid()
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), "John", "Doe", GradeLevel.Kinder1);

        // Act
        var response = (GetTeacherResponse?)teacher;

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
        var exception = Assert.Throws<ArgumentNullException>(() => (GetTeacherResponse?)teacher);
        Assert.Equal("Teacher cannot be null (Parameter 'teacher')", exception.Message);
    }
}
