using KinderGartenApp.Core.Entities;
using KinderGartenApp.Persistence.Contexts;
using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class ParentRepositoryTests
{
    [Fact]
    public void Constructor_With_Valid_Context_Should_Create_Instance()
    {
        // Arrange
        var context = TestContextFactory.Create();

        // Act
        var repository = new ParentRepository(context);

        // Assert
        Assert.NotNull(repository);
    }

    [Fact]
    public void Constructor_With_Null_Context_Should_Throw_ArgumentNullException()
    {
        // Arrange
        KinderGartenContext? nullContext = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new ParentRepository(nullContext!));
    }

    [Fact]
    public void Constructor_With_Invalid_Context_Should_Throw_InvalidOperationException()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<KinderGartenContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        // Act
        var contextMock = new Mock<KinderGartenContext>(options);
        contextMock.Setup(c => c.Set<Parent>()).Returns((DbSet<Parent>)null!);

        // Assert
        var exception = Assert.Throws<InvalidOperationException>(() => new ParentRepository(contextMock.Object));
        Assert.Equal($"The DbSet for '{typeof(Parent)}' could not be obtained from the context.", exception.Message);
    }
}
