using KinderGartenApp.Application.DTOs.Children.Get;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Tests.Application.DTOs.Children.Gets;

public class GetStudentResponseTests
{
    [Fact]
    public void ExplicitConversion_ShouldConvertToGetChildResponse_WhenStudentIsValid()
    {
        // Arrange
        var student = Child.Create(Guid.NewGuid(), "Mateo", "Quiceno", DateTime.Now.AddYears(-7), GradeLevel.PreKinder, new Guid(), new Guid());

        // Act
        var response = (GetChildResponse?)student;

        // Assert
        Assert.NotNull(response);
        Assert.Equal(student.Id, response.Id);
        Assert.Equal(student.FirstName, response.FirstName);
        Assert.Equal(student.LastName, response.LastName);
        Assert.Equal(student.GradeLevel, response.GradeLevel);
    }

    [Fact]
    public void ExplicitConversion_ShouldThrowArgumentNullException_WhenStudentIsNull()
    {
        // Arrange
        Child? student = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => (GetChildResponse?)student);
        Assert.Equal("Child cannot be null (Parameter 'child')", exception.Message);
    }
}
