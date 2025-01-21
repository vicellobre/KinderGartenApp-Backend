using KinderGartenApp.Application.DTOs.Children.Update;
using KinderGartenApp.Core.Contracts.Repositories;
using KinderGartenApp.Core.Contracts.UnitOfWorks;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Errors;
using KinderGartenApp.Infrastructure.Services;
using Moq;

namespace KinderGartenApp.Tests.Infrastructure.Services;

public partial class ChildServiceTests
{
    [Fact]
    public async Task Update_ShouldUpdateChild_WhenMessageIsValid()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockChildRepository = new Mock<IChildRepository>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockParentRepository = new Mock<IParentRepository>();

        var existingChild = Child.Create(Guid.NewGuid(), "David", "Martinez", DateTime.Now.AddYears(-5), GradeLevel.PreKinder, Guid.NewGuid(), Guid.NewGuid());
        var message = new UpdateChildMessage
        {
            Id = existingChild.Id,
            FirstName = "Mateo",
            LastName = "Quiceno",
            GradeLevel = GradeLevel.Kinder2
        };

        mockChildRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(existingChild);
        mockUnitOfWork.Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(1));


        var service = new ChildService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockChildRepository.Object, mockParentRepository.Object);

        // Act
        var result = await service.Update(message);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.Equal(message.FirstName, result.Value.FirstName);
        Assert.Equal(message.LastName, result.Value.LastName);
        Assert.Equal(message.GradeLevel, result.Value.GradeLevel);
    }

    [Fact]
    public async Task Update_ShouldReturnError_WhenChildNotFound()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockChildRepository = new Mock<IChildRepository>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockParentRepository = new Mock<IParentRepository>();

        mockChildRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync((Child?)null);

        var service = new ChildService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockChildRepository.Object, mockParentRepository.Object);

        var message = new UpdateChildMessage
        {
            Id = Guid.NewGuid(),
            FirstName = "Mateo",
            LastName = "Quiceno",
            GradeLevel = GradeLevel.Kinder2
        };

        // Act
        var result = await service.Update(message);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(Error.Children.NotFound.Code, result.FirstError.Code);
        Assert.Equal(Error.Children.NotFound.Message, result.FirstError.Message);
    }

    [Fact]
    public async Task Update_ShouldReturnError_WhenValidationFails()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockChildRepository = new Mock<IChildRepository>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockParentRepository = new Mock<IParentRepository>();

        var existingChild = Child.Create(Guid.NewGuid(), "David", "Martinez", DateTime.Now.AddYears(-5), GradeLevel.PreKinder, Guid.NewGuid(), Guid.NewGuid());
        var message = new UpdateChildMessage
        {
            Id = existingChild.Id,
            FirstName = "", // Nombre inválido
            LastName = "Quiceno",
            GradeLevel = GradeLevel.Kinder2
        };

        mockChildRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(existingChild);

        var service = new ChildService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockChildRepository.Object, mockParentRepository.Object);

        // Act
        var result = await service.Update(message);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(Error.FirstName.IsNullOrEmpty.Code, result.FirstError.Code);
        Assert.Equal(Error.FirstName.IsNullOrEmpty.Message, result.FirstError.Message);
    }

    [Fact]
    public async Task Update_ShouldReturnFailureResult_WhenExceptionOccurs()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockChildRepository = new Mock<IChildRepository>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockParentRepository = new Mock<IParentRepository>();

        var existingChild = Child.Create(Guid.NewGuid(), "David", "Martinez", DateTime.Now.AddYears(-5), GradeLevel.PreKinder, Guid.NewGuid(), Guid.NewGuid());
        var message = new UpdateChildMessage
        {
            Id = existingChild.Id,
            FirstName = "Mateo",
            LastName = "Quiceno",
            GradeLevel = GradeLevel.Kinder1
        };

        mockChildRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(existingChild);
        mockUnitOfWork.Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>())).Throws(new InvalidOperationException("Database error"));

        var service = new ChildService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockChildRepository.Object, mockParentRepository.Object);

        // Act
        var result = await service.Update(message);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("InvalidOperationException", result.FirstError.Code);
        Assert.Equal("Database error", result.FirstError.Message);
    }
}
