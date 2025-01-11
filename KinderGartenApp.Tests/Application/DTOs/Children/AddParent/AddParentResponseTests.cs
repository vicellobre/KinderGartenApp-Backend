using KinderGartenApp.Application.DTOs.Children.AddParent;

namespace KinderGartenApp.Tests.Application.DTOs.Children.AddParent;

public class AddParentResponseTests
{
    [Fact]
    public void AddParentResponse_ShouldInitializeProperly()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var studentFirstName = "David";
        var studentLastName = "Martinez";
        var parentId = Guid.NewGuid();
        var parentFirstName = "Mateo";
        var parentLastName = "Quiceno";

        // Act
        var response = new AddParentResponse
        {
            ParentId = parentId,
            ParentFirstName = parentFirstName,
            ParentLastName = parentLastName,
            ChildId = studentId,
            ChildFirstName = studentFirstName,
            ChildLastName = studentLastName
        };

        // Assert
        Assert.Equal(studentId, response.ChildId);
        Assert.Equal(studentFirstName, response.ChildFirstName);
        Assert.Equal(studentLastName, response.ChildLastName);
        Assert.Equal(parentId, response.ParentId);
        Assert.Equal(parentFirstName, response.ParentFirstName);
        Assert.Equal(parentLastName, response.ParentLastName);
    }
}
