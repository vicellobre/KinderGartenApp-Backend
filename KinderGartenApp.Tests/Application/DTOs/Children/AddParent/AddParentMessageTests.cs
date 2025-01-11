using KinderGartenApp.Application.DTOs.Children.AddParent;

namespace KinderGartenApp.Tests.Application.DTOs.Children.AddParent;

public class AddParentMessageTests
{
    [Fact]
    public void AddParentMessage_ShouldInitializeProperly()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var parentId = Guid.NewGuid();

        // Act
        var message = new AddParentMessage
        {
            ChildId = studentId,
            ParentId = parentId
        };

        // Assert
        Assert.Equal(studentId, message.ChildId);
        Assert.Equal(parentId, message.ParentId);
    }
}
