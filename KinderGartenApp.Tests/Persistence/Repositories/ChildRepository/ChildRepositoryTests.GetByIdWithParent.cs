using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class ChildRepositoryTests
{
    [Fact]
    public async Task Can_Get_Child_With_Parent_By_Id()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ChildRepository(context);

        // Act
        var child = await context.Children.Include(c => c.Parent).FirstOrDefaultAsync();
        Assert.NotNull(child);

        var result = await repository.GetByIdWithParentAsNoTrackingAsync(child.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(child.Id, result.Id);
        Assert.NotNull(result.Parent);
        Assert.Equal(child.Parent, result.Parent);
    }

    [Fact]
    public async Task Can_Get_Child_With_Parent_By_Id_Should_Not_Track_Changes()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithCleanTranker();
        var repository = new ChildRepository(context);

        // Act
        var child = await context.Children.AsNoTracking().Include(c => c.Parent).FirstOrDefaultAsync();
        // Assert
        Assert.NotNull(child);

        var result = await repository.GetByIdWithParentAsNoTrackingAsync(child.Id);

        var trackedEntities = context.ChangeTracker.Entries();

        // Assert
        Assert.Empty(trackedEntities);
    }

    [Fact]
    public async Task Get_Child_With_Parent_By_Id_Should_Return_Null_If_Not_Found()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ChildRepository(context);

        // Act
        var nonExistentChildId = Guid.NewGuid();

        var result = await repository.GetByIdWithParentAsNoTrackingAsync(nonExistentChildId);

        // Assert
        Assert.Null(result);
    }
}
