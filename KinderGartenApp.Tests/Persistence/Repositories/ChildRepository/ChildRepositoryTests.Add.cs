using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class ChildRepositoryTests
{
    [Fact]
    public async Task Can_Add_Child()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ChildRepository(context);

        // Act
        var newChild = Child.Create(Guid.NewGuid(), "Mateo", "Quiceno", DateTime.Today.AddYears(-6), GradeLevel.Kinder1, Guid.NewGuid(), Guid.NewGuid());
        repository.Add(newChild);
        await context.SaveChangesAsync();

        // Assert
        var savedChild = await repository.GetByIdAsync(newChild.Id);
        Assert.NotNull(savedChild);
        Assert.Equal("Mateo", savedChild.FirstName);
        Assert.Equal(GradeLevel.Kinder1, savedChild.GradeLevel);
    }

    [Fact]
    public async Task Cant_Add_Null_Child()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ChildRepository(context);
        var initialCount = await context.Children.CountAsync();
        Child? nullChild = null;

        // Act
        await Assert.ThrowsAsync<ArgumentNullException>(() => {
            repository.Add(nullChild!);
            return context.SaveChangesAsync();
        });
        var finalCount = await context.Children.CountAsync();

        // Assert
        Assert.Equal(initialCount, finalCount);
    }

    [Fact]
    public async Task Cant_Add_Duplicate_Child()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ChildRepository(context);
        var existingChild = await context.Children.FirstAsync();

        // Act
        context.Entry(existingChild).State = EntityState.Detached;
        var duplicateChild = Child.Create(existingChild.Id, existingChild.FirstName, existingChild.LastName, existingChild.BirthDate, existingChild.GradeLevel, existingChild.ParentId, existingChild.TeacherId);

        await Assert.ThrowsAsync<ArgumentException>(() => {
            repository.Add(duplicateChild);
            return context.SaveChangesAsync();
        });

        // Assert
        var children = await repository.GetAllAsync();
        var count = await context.Children.CountAsync(c => c.Id == existingChild.Id);
        Assert.Equal(1, count);
    }
}
