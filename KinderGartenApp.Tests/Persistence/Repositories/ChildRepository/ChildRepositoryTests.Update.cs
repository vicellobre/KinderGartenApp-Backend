using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class ChildRepositoryTests
{
    [Fact]
    public async Task Can_Update_Child()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ChildRepository(context);

        // Act
        var child = await context.Children.FirstAsync();

        child.FirstName = "UpdatedName";
        repository.Update(child);
        await context.SaveChangesAsync();

        var updatedChild = await repository.GetByIdAsync(child.Id);

        // Assert
        Assert.NotNull(updatedChild);
        Assert.Equal("UpdatedName", updatedChild.FirstName);
    }

    [Fact]
    public async Task Cannot_Update_Null_Child_With_Clean_ChangeTracker()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithCleanTranker();
        var repository = new ChildRepository(context);

        // Act
        Child? nullChild = null;

        await Assert.ThrowsAsync<NullReferenceException>(() => {
            repository.Update(nullChild!);
            return context.SaveChangesAsync();
        });

        var children = await repository.GetAllAsync();

        // Assert
        Assert.All(children, c => Assert.NotNull(c.FirstName));
    }

    [Fact]
    public async Task Cannot_Update_Null_Child_With_Unclean_ChangeTracker()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ChildRepository(context);

        // Act
        Child? nullChild = null;

        await Assert.ThrowsAsync<ArgumentNullException>(() => {
            repository.Update(nullChild!);
            return context.SaveChangesAsync();
        });

        var children = await repository.GetAllAsync();

        // Assert
        Assert.All(children, c => Assert.NotNull(c.FirstName));
    }

    [Fact]
    public async Task Cant_Update_NonExistent_Child()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ChildRepository(context);

        // Act
        var nonExistentChild = Child.Create(Guid.NewGuid(), "Non", "Existent", DateTime.Today.AddYears(-6), GradeLevel.Kinder1, Guid.NewGuid(), Guid.NewGuid());

        nonExistentChild.FirstName = "UpdatedName";
        repository.Update(nonExistentChild);

        await Assert.ThrowsAsync<DbUpdateConcurrencyException>(() => {
            return context.SaveChangesAsync();
        });

        var children = await repository.GetAllAsync();

        // Assert
        Assert.All(children, c => Assert.NotEqual("Non", c.FirstName));
    }
}
