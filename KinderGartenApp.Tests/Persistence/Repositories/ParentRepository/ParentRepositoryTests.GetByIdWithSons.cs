using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class ParentRepositoryTests
{
    [Fact]
    public async Task Can_Get_Parent_With_Sons_By_Id()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ParentRepository(context);

        // Act
        var parent = await context.Parents.Include(p => p.Sons).FirstOrDefaultAsync();
        Assert.NotNull(parent);

        var result = await repository.GetByIdWithSonsAsNoTrackingAsync(parent.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(parent.Id, result.Id);
        Assert.NotNull(result.Sons);
        Assert.Equal(parent.Sons.Count, result.Sons.Count);
    }

    [Fact]
    public async Task Can_Get_Parent_With_Sons_By_Id_Should_Not_Track_Changes()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithCleanTranker();
        var repository = new ParentRepository(context);

        // Act
        var parent = await context.Parents.AsNoTracking().Include(p => p.Sons).FirstOrDefaultAsync();
        Assert.NotNull(parent);

        var result = await repository.GetByIdWithSonsAsNoTrackingAsync(parent.Id);

        var trackedEntities = context.ChangeTracker.Entries();

        // Assert
        Assert.Empty(trackedEntities);
    }

    [Fact]
    public async Task Get_Parent_With_Sons_By_Id_Should_Return_Null_If_Not_Found()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ParentRepository(context);

        // Act
        var nonExistentParentId = Guid.NewGuid();

        var result = await repository.GetByIdWithSonsAsNoTrackingAsync(nonExistentParentId);

        // Assert
        Assert.Null(result);
    }
}
