using KinderGartenApp.Application.DTOs.Children.Get;

namespace KinderGartenApp.Tests.Application.DTOs.Children.Gets;

public class GetStudentMessageTests
{
    [Fact]
    public void GetStudentMessage_ShouldInitializeProperly()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        var message = new GetChildMessage { Id = id };

        // Assert
        Assert.Equal(id, message.Id);
    }
}
