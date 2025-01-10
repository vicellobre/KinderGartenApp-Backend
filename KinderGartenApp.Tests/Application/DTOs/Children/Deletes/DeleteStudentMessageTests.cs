using KinderGartenApp.Application.DTOs.Children.Deletes;

namespace KinderGartenApp.Tests.Application.DTOs.Children.Deletes;

public class DeleteStudentMessageTests
{
    [Fact]
    public void DeleteStudentMessage_ShouldInitializeProperly()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        var message = new DeleteChildMessage { Id = id };

        // Assert
        Assert.Equal(id, message.Id);
    }
}

