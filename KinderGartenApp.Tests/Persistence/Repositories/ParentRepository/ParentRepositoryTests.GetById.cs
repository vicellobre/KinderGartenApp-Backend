using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class ParentRepositoryTests
{
    [Fact]
    public async Task Can_Get_Parent_By_Id()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ParentRepository(context);

        // Act
        var parent = await context.Parents.FirstAsync();
        var retrievedParent = await repository.GetByIdAsync(parent.Id);

        // Assert
        Assert.NotNull(retrievedParent);
        Assert.Equal(parent.Id, retrievedParent.Id);
        Assert.Equal(parent.FirstName, retrievedParent.FirstName);

        var nonExistentParent = await repository.GetByIdAsync(Guid.NewGuid());
        Assert.Null(nonExistentParent);
    }

    [Fact]
    public async Task Cant_Get_Parent_By_Id()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ParentRepository(context);

        // Act
        var nonExistentParent = await repository.GetByIdAsync(Guid.NewGuid());

        // Assert
        Assert.Null(nonExistentParent);
    }
}
