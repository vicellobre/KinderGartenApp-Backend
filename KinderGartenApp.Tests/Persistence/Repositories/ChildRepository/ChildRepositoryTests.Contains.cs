using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class ChildRepositoryTests
{
    [Fact]
    public async Task Can_Check_If_Child_Exists()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ChildRepository(context);

        // Act
        var child = await context.Children.FirstAsync();

        // Assert
        var exists = await repository.ContainsAsync(child.Id);
        Assert.True(exists);
    }

    [Fact]
    public async Task Can_Check_If_Child_NotExists()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ChildRepository(context);

        // Act & Assert
        var nonExists = await repository.ContainsAsync(Guid.NewGuid());
        Assert.False(nonExists);
    }
}
