using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class ParentRepositoryTests
{
    [Fact]
    public async Task Can_Get_All_Parents()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ParentRepository(context);

        // Act
        var parents = await repository.GetAllAsync();

        // Assert
        Assert.NotNull(parents);
        Assert.NotEmpty(parents);
    }

    [Fact]
    public async Task Cant_Get_All_Parents()
    {
        // Arrange
        var context = TestContextFactory.Create();
        var repository = new ParentRepository(context);

        // Act
        var parents = await repository.GetAllAsync();

        // Assert
        Assert.NotNull(parents);
        Assert.Empty(parents);
    }
}
