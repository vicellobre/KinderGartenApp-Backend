using KinderGartenApp.Persistence.Contexts;
using KinderGartenApp.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;

namespace KinderGartenApp.Tests.Persistence.UnitOfWorks;

public partial class UnitOfWorkTests
{
    [Fact]
    public void Constructor_ValidDbContext_ShouldCreateInstance()
    {
        // Arrange
        var context = new Mock<DbContext>();

        // Act
        var unitOfWork = new UnitOfWork(context.Object);

        // Assert
        Assert.NotNull(unitOfWork);
    }

    [Fact]
    public void Constructor_NullDbContext_ShouldThrowArgumentNullException()
    {
        // Arrange
        DbContext? context = null;

        // ACT
        UnitOfWork result() => new(context);

        // ASSERT
        Assert.Throws<ArgumentNullException>(result);
    }
}