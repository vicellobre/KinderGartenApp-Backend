using KinderGartenApp.Application.DTOs.Teachers.Get;

namespace KinderGartenApp.Tests.Application.DTOs.Teachers.Gets;

public class GetTeacherMessageTests
{
    [Fact]
    public void GetTeacherMessage_ShouldInitializeProperly()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        var message = new GetTeacherMessage { Id = id };

        // Assert
        Assert.Equal(id, message.Id);
    }
}
