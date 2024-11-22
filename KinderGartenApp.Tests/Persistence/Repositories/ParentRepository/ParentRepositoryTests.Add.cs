using KinderGartenApp.Core.Entities;
using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class ParentRepositoryTests
{
    [Fact]
    public async Task Can_Add_Parent()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ParentRepository(context);

        // Act
        var newParent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "12345678", "1234567890");
        repository.Add(newParent);
        await context.SaveChangesAsync();

        // Assert
        var savedParent = await repository.GetByIdAsync(newParent.Id);
        Assert.NotNull(savedParent);
        Assert.Equal("David", savedParent.FirstName);
        Assert.Equal("David@gmail.com", savedParent.Email);
    }

    [Fact]
    public async Task Cant_Add_Null_Parent()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ParentRepository(context);
        var initialCount = await context.Parents.CountAsync();
        Parent? nullParent = null;

        // Act
        await Assert.ThrowsAsync<ArgumentNullException>(() =>
        {
            repository.Add(nullParent!);
            return context.SaveChangesAsync();
        });
        var finalCount = await context.Parents.CountAsync();

        // Assert
        Assert.Equal(initialCount, finalCount);
    }

    [Fact]
    public async Task Cant_Add_Duplicate_Parent()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ParentRepository(context);
        var existingParent = await context.Parents.FirstAsync();

        // Act
        context.Entry(existingParent).State = EntityState.Detached;
        var duplicateParent = Parent.Create(existingParent.Id, existingParent.FirstName, existingParent.LastName, existingParent.Email, existingParent.Password, existingParent.Phone);

        await Assert.ThrowsAsync<ArgumentException>(() =>
        {
            repository.Add(duplicateParent);
            return context.SaveChangesAsync();
        });

        // Assert
        var Parents = await repository.GetAllAsync();
        var count = await context.Parents.CountAsync(p => p.Id == existingParent.Id);
        Assert.Equal(1, count);
    }
}
