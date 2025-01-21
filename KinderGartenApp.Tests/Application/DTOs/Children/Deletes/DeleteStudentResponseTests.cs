using KinderGartenApp.Application.DTOs.Children.Deletes;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Tests.Application.DTOs.Children.Deletes;

public class DeleteStudentResponseTests
{
    [Fact]
    public void DeleteStudentResponse_ShouldInitializeProperly()
    {
        // Arrange
        var id = Guid.NewGuid();
        var firstName = "David";
        var lastName = "Martinez";

        // Act
        var response = new DeleteChildResponse
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName
        };

        // Assert
        Assert.Equal(id, response.Id);
        Assert.Equal(firstName, response.FirstName);
        Assert.Equal(lastName, response.LastName);
    }

    [Fact]
    public void ExplicitConversion_ShouldConvertToDeleteStudentResponse_WhenStudentIsValid()
    {
        // Arrange
        var student = Child.Create(Guid.NewGuid(), "Mateo", "Quiceno", DateTime.Now.AddYears(-7), GradeLevel.PreKinder, new Guid(), new Guid());

        // Act
        var response = (DeleteChildResponse)student;

        // Assert
        Assert.NotNull(response);
        Assert.Equal(student.Id, response.Id);
        Assert.Equal(student.FirstName, response.FirstName);
        Assert.Equal(student.LastName, response.LastName);
    }

    [Fact]
    public void ExplicitConversion_ShouldThrowArgumentNullException_WhenStudentIsNull()
    {
        // Arrange
        Child? student = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => (DeleteChildResponse)student);
        Assert.Equal("Child cannot be null (Parameter 'child')", exception.Message);
    }
}
