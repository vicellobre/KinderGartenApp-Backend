using KinderGartenApp.Core.Entities;
using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class ParentRepositoryTests
{
    [Fact]
    public async Task Can_Get_Parent_By_Id_AsNoTracking()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithCleanTranker();
        var repository = new ParentRepository(context);

        // Act
        var parent = await context.Parents.AsNoTracking().FirstAsync();
        var retrievedParent = await repository.GetByIdAsNoTrackingAsync(parent.Id);

        // Assert
        Assert.NotNull(retrievedParent);
        Assert.Equal(parent.Id, retrievedParent.Id);
        Assert.Equal(parent.FirstName, retrievedParent.FirstName);

        var trackedEntities = context.ChangeTracker.Entries<Parent>();
        Assert.Empty(trackedEntities);
    }

    [Fact]
    public async Task Cant_Get_Parent_By_Id_AsNoTracking()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ParentRepository(context);

        // Act
        var nonExistentParent = await repository.GetByIdAsNoTrackingAsync(Guid.NewGuid());

        // Assert
        Assert.Null(nonExistentParent);
    }
}
