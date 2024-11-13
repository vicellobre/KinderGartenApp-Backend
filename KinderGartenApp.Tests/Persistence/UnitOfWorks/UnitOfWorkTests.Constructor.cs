using KinderGartenApp.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace KinderGartenApp.Tests.Persistence.UnitOfWorks;

public partial class UnitOfWorkTests
{
    [Fact]
    public void UnitOfWork_Constructor_ValidDbContext_ShouldCreateInstance()
    {
        // Arrange
        var context = new Mock<DbContext>();

        // Act
        var unitOfWork = new UnitOfWork(context.Object);

        // Assert
        Assert.NotNull(unitOfWork);
    }

    [Fact]
    public void UnitOfWork_Constructor_NullDbContext_ShouldThrowArgumentNullException()
    {
        // Arrange
        DbContext? context = null;

        // ACT
        UnitOfWork result() => new(context);

        // ASSERT
        Assert.Throws<ArgumentNullException>(result);
    }
}