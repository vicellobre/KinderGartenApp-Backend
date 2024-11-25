using KinderGartenApp.Application.DTOs.Teachers.Deletes;

namespace KinderGartenApp.Tests.Application.DTOs.Teachers.Deletes;

public class DeleteTeacherMessageTests
{
    [Fact]
    public void DeleteTeacherMessage_ShouldInitializeProperly()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        var message = new DeleteTeacherMessage { Id = id };

        // Assert
        Assert.Equal(id, message.Id);
    }
}

