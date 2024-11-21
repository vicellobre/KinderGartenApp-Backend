using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class ChildRepositoryTests
{
    [Fact]
    public async Task Can_Get_All_Children()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ChildRepository(context);

        // Act
        var children = await repository.GetAllAsync();

        // Assert
        Assert.NotNull(children);
        Assert.NotEmpty(children);
    }

    [Fact]
    public async Task Cant_Get_All_Children()
    {
        // Arrange
        var context = TestContextFactory.Create();
        var repository = new ChildRepository(context);

        // Act
        var children = await repository.GetAllAsync();

        // Assert
        Assert.NotNull(children);
        Assert.Empty(children);
    }
}
