using KinderGartenApp.Core.Entities;
using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class ParentRepositoryTests
{
    [Fact]
    public async Task Can_Update_Parent()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ParentRepository(context);

        // Act
        var parent = await context.Parents.FirstAsync();

        parent.FirstName = "UpdatedName";
        repository.Update(parent);
        await context.SaveChangesAsync();

        var updatedParent = await repository.GetByIdAsync(parent.Id);

        // Assert
        Assert.NotNull(updatedParent);
        Assert.Equal("UpdatedName", updatedParent.FirstName);
    }

    [Fact]
    public async Task Cannot_Update_Null_Parent_With_Clean_ChangeTracker()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithCleanTranker();
        var repository = new ParentRepository(context);

        // Act
        Parent? nullParent = null;

        await Assert.ThrowsAsync<NullReferenceException>(() => {
            repository.Update(nullParent!);
            return context.SaveChangesAsync();
        });

        var parents = await repository.GetAllAsync();

        // Assert
        Assert.All(parents, p => Assert.NotNull(p.FirstName));
    }

    [Fact]
    public async Task Cannot_Update_Null_Parent_With_Unclean_ChangeTracker()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ParentRepository(context);

        // Act
        Parent? nullParent = null;

        await Assert.ThrowsAsync<ArgumentNullException>(() => {
            repository.Update(nullParent!);
            return context.SaveChangesAsync();
        });

        var parents = await repository.GetAllAsync();

        // Assert
        Assert.All(parents, p => Assert.NotNull(p.FirstName));
    }

    [Fact]
    public async Task Cant_Update_NonExistent_Parent()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ParentRepository(context);

        // Act
        var nonExistentParent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "12345678mM*", "1234567890");

        nonExistentParent.FirstName = "UpdatedName";
        repository.Update(nonExistentParent);

        await Assert.ThrowsAsync<DbUpdateConcurrencyException>(() => {
            return context.SaveChangesAsync();
        });

        var parents = await repository.GetAllAsync();

        // Assert
        Assert.All(parents, p => Assert.NotEqual("Non", p.FirstName));
    }
}
