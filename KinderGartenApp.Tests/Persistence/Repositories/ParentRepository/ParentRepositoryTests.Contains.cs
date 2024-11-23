using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class ParentRepositoryTests
{
    [Fact]
    public async Task Can_Check_If_Parent_Exists()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ParentRepository(context);

        // Act
        var parent = await context.Parents.FirstAsync();

        // Assert
        var exists = await repository.Contains(parent.Id);
        Assert.True(exists);
    }

    [Fact]
    public async Task Can_Check_If_Parent_NotExists()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ParentRepository(context);

        // Act & Assert
        var nonExists = await repository.Contains(Guid.NewGuid());
        Assert.False(nonExists);
    }
}
