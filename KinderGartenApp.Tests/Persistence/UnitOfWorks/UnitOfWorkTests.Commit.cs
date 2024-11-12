using KinderGartenApp.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace KinderGartenApp.Tests.Persistence.UnitOfWorks;

public partial class UnitOfWorkTests
{
    [Fact]
    public void Commit_Should_SaveChanges_OnDbContext()
    {
        // Arrange
        var dbContextMock = new Mock<DbContext>();
        dbContextMock
            .Setup(x => x.SaveChanges())
            .Returns(1); // Simula un commit exitoso.

        var unitOfWork = new UnitOfWork(dbContextMock.Object);

        // Act
        unitOfWork.Commit();

        // Assert
        dbContextMock.Verify(m => m.SaveChanges(), Times.Once);
    }

    [Fact]
    public void Commit_FailedCommit()
    {
        // Arrange
        var mockDbContext = new Mock<DbContext>();
        mockDbContext
            .Setup(x => x.SaveChanges())
            .Throws(new DbUpdateException()); // Simula una excepción durante el commit.

        var unitOfWork = new UnitOfWork(mockDbContext.Object);

        // Act & Assert
        Assert.Throws<DbUpdateException>(() => unitOfWork.Commit());
    }
}