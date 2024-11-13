﻿using KinderGartenApp.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace KinderGartenApp.Tests.Persistence.UnitOfWorks;

public partial class UnitOfWorkTests
{
    [Fact]
    public async Task UnitOfWork_CommitAsync_Should_SaveChangesAsync_OnDbContext()
    {
        // Arrange
        var dbContextMock = new Mock<DbContext>();
        dbContextMock
            .Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1); // Simula una operación exitosa


        var unitOfWork = new UnitOfWork(dbContextMock.Object);

        // Act
        await unitOfWork.CommitAsync();

        // Assert
        dbContextMock.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task UnitOfWork_CommitAsync_FailedCommit()
    {
        // Arrange
        var mockDbContext = new Mock<DbContext>();
        mockDbContext
            .Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ThrowsAsync(new DbUpdateException()); // Simula una excepción durante el commit.

        var unitOfWork = new UnitOfWork(mockDbContext.Object);

        // Act & Assert
        await Assert.ThrowsAsync<DbUpdateException>(() => unitOfWork.CommitAsync());
    }
}