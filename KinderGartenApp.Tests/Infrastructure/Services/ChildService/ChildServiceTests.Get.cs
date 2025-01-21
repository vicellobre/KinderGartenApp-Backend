using KinderGartenApp.Application.DTOs.Children.Get;
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
    public async Task Get_ShouldReturnChild_WhenIdIsValid()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockChildRepository = new Mock<IChildRepository>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockParentRepository = new Mock<IParentRepository>();

        var child = Child.Create(Guid.NewGuid(), "David", "Martinez", DateTime.Now.AddYears(-5), GradeLevel.PreKinder, Guid.NewGuid(), Guid.NewGuid());
        mockChildRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(child);

        var service = new ChildService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockChildRepository.Object, mockParentRepository.Object);

        var message = new GetChildMessage { Id = child.Id };

        // Act
        var result = await service.Get(message);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.Equal(child.Id, result.Value.Id);
        Assert.Equal(child.FirstName, result.Value.FirstName);
        Assert.Equal(child.LastName, result.Value.LastName);
        Assert.Equal(child.GradeLevel, result.Value.GradeLevel);
    }

    [Fact]
    public async Task Get_ShouldReturnError_WhenChildNotFound()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockChildRepository = new Mock<IChildRepository>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockParentRepository = new Mock<IParentRepository>();

        mockChildRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync((Child?)null);

        var service = new ChildService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockChildRepository.Object, mockParentRepository.Object);

        var message = new GetChildMessage { Id = Guid.NewGuid() };

        // Act
        var result = await service.Get(message);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(Error.Children.NotFound.Code, result.FirstError.Code);
        Assert.Equal(Error.Children.NotFound.Message, result.FirstError.Message);
    }

    [Fact]
    public async Task Get_ShouldReturnFailureResult_WhenExceptionOccurs()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockChildRepository = new Mock<IChildRepository>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockParentRepository = new Mock<IParentRepository>();

        mockChildRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).Throws(new InvalidOperationException("Database error"));

        var service = new ChildService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockChildRepository.Object, mockParentRepository.Object);

        var message = new GetChildMessage { Id = Guid.NewGuid() };

        // Act
        var result = await service.Get(message);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("InvalidOperationException", result.FirstError.Code);
        Assert.Equal("Database error", result.FirstError.Message);
    }
}
