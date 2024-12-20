﻿using KinderGartenApp.API.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace KinderGartenApp.Tests.API.UnitOfWorks;

public partial class UnitOfWorkTests
{
    [Fact]
    public void Dispose_WhenCalled_DisposesContext()
    {
        // Arrange
        var mockDbContext = new Mock<DbContext>();
        var unitOfWork = new UnitOfWork(mockDbContext.Object);

        // Act
        unitOfWork.Dispose();

        // Assert
        mockDbContext.Verify(m => m.Dispose(), Times.Once);
    }

    [Fact]
    public void Dispose_WhenCalledMultipleTimes_DisposesContextOnlyOnce()
    {
        // Arrange
        var mockDbContext = new Mock<DbContext>();
        var unitOfWork = new UnitOfWork(mockDbContext.Object);

        // Act
        unitOfWork.Dispose();
        unitOfWork.Dispose(); // Segunda llamada

        // Assert
        mockDbContext.Verify(m => m.Dispose(), Times.Once);
    }

    [Fact]
    public void Dispose_WhenDbContextThrowsException_HandlesExceptionGracefully()
    {
        // Arrange
        var mockDbContext = new Mock<DbContext>();
        mockDbContext.Setup(m => m.Dispose()).Throws(new Exception("Test Exception"));
        var unitOfWork = new UnitOfWork(mockDbContext.Object);

        // Act
        // Verificamos que la excepción se maneje al llamar a Dispose
        var exception = Record.Exception(() => unitOfWork.Dispose());

        // Assert
        Assert.Null(exception); // No debería lanzar ninguna excepción
    }
}