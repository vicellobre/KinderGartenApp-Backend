using KinderGartenApp.Core.Entities;
using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class ChildRepositoryTests
{
    [Fact]
    public async Task Can_Get_Child_By_Id_AsNoTracking()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithCleanTranker();
        var repository = new ChildRepository(context);

        // Act
        var child = await context.Children.AsNoTracking().FirstAsync();
        var retrievedChild = await repository.GetByIdAsNoTrackingAsync(child.Id);

        // Assert
        Assert.NotNull(retrievedChild);
        Assert.Equal(child.Id, retrievedChild.Id);
        Assert.Equal(child.FirstName, retrievedChild.FirstName);

        var trackedEntities = context.ChangeTracker.Entries<Child>();
        Assert.Empty(trackedEntities);
    }

    [Fact]
    public async Task Cant_Get_Child_By_Id_AsNoTracking()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ChildRepository(context);

        // Act
        var nonExistentChild = await repository.GetByIdAsNoTrackingAsync(Guid.NewGuid());

        // Assert
        Assert.Null(nonExistentChild);
    }
}
