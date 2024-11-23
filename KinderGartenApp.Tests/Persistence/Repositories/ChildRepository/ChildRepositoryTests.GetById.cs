using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class ChildRepositoryTests
{
    [Fact]
    public async Task Can_Get_Child_By_Id()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ChildRepository(context);

        // Act
        var child = await context.Children.FirstAsync();
        var retrievedChild = await repository.GetByIdAsync(child.Id);

        // Assert
        Assert.NotNull(retrievedChild);
        Assert.Equal(child.Id, retrievedChild.Id);
        Assert.Equal(child.FirstName, retrievedChild.FirstName);

        var nonExistentChild = await repository.GetByIdAsync(Guid.NewGuid());
        Assert.Null(nonExistentChild);
    }

    [Fact]
    public async Task Cant_Get_Child_By_Id()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ChildRepository(context);

        // Act
        var nonExistentChild = await repository.GetByIdAsync(Guid.NewGuid());

        // Assert
        Assert.Null(nonExistentChild);
    }
}
