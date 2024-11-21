using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class ChildRepositoryTests
{
    [Fact]
    public async Task Can_Delete_Child()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ChildRepository(context);

        // Act
        var child = await context.Children.FirstAsync();

        repository.Delete(child);
        await context.SaveChangesAsync();

        // Assert
        var deletedChild = await repository.GetByIdAsync(child.Id);
        Assert.Null(deletedChild);
    }

    [Fact]
    public async Task Cant_Delete_Null_Child()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ChildRepository(context);

        // Act
        var initialCount = await context.Children.CountAsync();

        Child? nullChild = null;

        await Assert.ThrowsAsync<ArgumentNullException>(() => {
            repository.Delete(nullChild!);
            return context.SaveChangesAsync();
        });

        var finalCount = await context.Children.CountAsync();

        // Assert
        Assert.Equal(initialCount, finalCount);
    }

    [Fact]
    public async Task Cant_Delete_NonExistent_Child()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ChildRepository(context);

        // Act
        var initialCount = await context.Children.CountAsync();

        var nonExistentChild = Child.Create(Guid.NewGuid(), "Non", "Existent", DateTime.Today.AddYears(-6), GradeLevel.Kinder3, Guid.NewGuid(), Guid.NewGuid());

        await Assert.ThrowsAsync<DbUpdateConcurrencyException>(() => {
            repository.Delete(nonExistentChild);
            return context.SaveChangesAsync();
        });

        var finalCount = await context.Children.CountAsync();

        // Assert
        Assert.Equal(initialCount, finalCount);
    }
}
