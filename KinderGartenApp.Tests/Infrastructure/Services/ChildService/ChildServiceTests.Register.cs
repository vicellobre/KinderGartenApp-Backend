using KinderGartenApp.Application.DTOs.Children.Register;
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
    public async Task Register_ShouldRegisterChild_WhenValidRequest()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockChildRepository = new Mock<IChildRepository>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockParentRepository = new Mock<IParentRepository>();

        var message = new RegisterChildMessage
        {
            FirstName = "David",
            LastName = "Martinez",
            GradeLevel = GradeLevel.PreKinder
        };

        var child = (Child?)message;

        mockChildRepository.Setup(repo => repo.Add(It.IsAny<Child>()));
        mockUnitOfWork.Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(1));

        var service = new ChildService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockChildRepository.Object, mockParentRepository.Object);

        // Act
        var result = await service.Register(message);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.NotNull(child);
        Assert.Equal(child.FirstName, result.Value.FirstName);
        Assert.Equal(child.LastName, result.Value.LastName);
    }

    [Fact]
    public async Task Register_ShouldReturnError_WhenValidationFails()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockChildRepository = new Mock<IChildRepository>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockParentRepository = new Mock<IParentRepository>();

        var message = new RegisterChildMessage
        {
            FirstName = "", // Nombre inválido
            LastName = "Martinez",
            GradeLevel = GradeLevel.Kinder2
        };

        var service = new ChildService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockChildRepository.Object, mockParentRepository.Object);

        // Act
        var result = await service.Register(message);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(Error.FirstName.IsNullOrEmpty.Code, result.FirstError.Code);
        Assert.Equal(Error.FirstName.IsNullOrEmpty.Message, result.FirstError.Message);
    }

    [Fact]
    public async Task Register_ShouldReturnFailureResult_WhenExceptionOccurs()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockChildRepository = new Mock<IChildRepository>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockParentRepository = new Mock<IParentRepository>();

        var message = new RegisterChildMessage
        {
            FirstName = "David",
            LastName = "Martinez",
            GradeLevel = GradeLevel.Kinder1
        };

        var child = (Child?)message;

        mockChildRepository.Setup(repo => repo.Add(It.IsAny<Child>())).Throws(new InvalidOperationException("Database error"));

        var service = new ChildService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockChildRepository.Object, mockParentRepository.Object);

        // Act
        var result = await service.Register(message);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("InvalidOperationException", result.FirstError.Code);
        Assert.Equal("Database error", result.FirstError.Message);
    }
}
