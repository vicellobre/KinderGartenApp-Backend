using KinderGartenApp.Core.Entities;
using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class ParentRepositoryTests
{
    [Fact]
    public async Task Can_Get_Parent_By_Email()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ParentRepository(context);

        // Act
        var newParent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "12345678mM*", "1234567890");
        repository.Add(newParent);
        await context.SaveChangesAsync();
        var email = "David@gmail.com";
        var parentByEmail = await repository.GetByEmailAsNoTrackingAsync(email);

        // Assert
        Assert.NotNull(parentByEmail);
        Assert.Equal(newParent, parentByEmail);
    }

    [Fact]
    public async Task Cant_Get_Parent_By_Email_When_Empty()
    {
        // Arrange
        var context = TestContextFactory.Create();
        var repository = new ParentRepository(context);

        // Act
        var newParent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "12345678mM*", "1234567890");
        repository.Add(newParent);
        await context.SaveChangesAsync();
        var emptyEmail = "";
        var emptyParent = await repository.GetByEmailAsNoTrackingAsync(emptyEmail);

        // Assert
        Assert.Null(emptyParent);
    }
}
