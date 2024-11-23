using KinderGartenApp.Core.Entities;
using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class ParentRepositoryTests
{
    [Fact]
    public async Task Can_Delete_Parent()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ParentRepository(context);

        // Act
        var parent = await context.Parents.FirstAsync();

        repository.Delete(parent);
        await context.SaveChangesAsync();

        // Assert
        var deletedParent = await repository.GetByIdAsync(parent.Id);
        Assert.Null(deletedParent);
    }

    [Fact]
    public async Task Cant_Delete_Null_Parent()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ParentRepository(context);

        // Act
        var initialCount = await context.Parents.CountAsync();

        Parent? nullParent = null;

        await Assert.ThrowsAsync<ArgumentNullException>(() => {
            repository.Delete(nullParent!);
            return context.SaveChangesAsync();
        });

        var finalCount = await context.Parents.CountAsync();

        // Assert
        Assert.Equal(initialCount, finalCount);
    }

    [Fact]
    public async Task Cant_Delete_NonExistent_Parent()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ParentRepository(context);

        // Act
        var initialCount = await context.Parents.CountAsync();

        var nonExistentParent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "12345678mM*", "1234567890");

        await Assert.ThrowsAsync<DbUpdateConcurrencyException>(() => {
            repository.Delete(nonExistentParent);
            return context.SaveChangesAsync();
        });

        var finalCount = await context.Parents.CountAsync();

        // Assert
        Assert.Equal(initialCount, finalCount);
    }
}
