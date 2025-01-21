using KinderGartenApp.Application.DTOs.Children.AddParent;
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
    public async Task AddParent_ShouldAddParent_WhenChildAndParentIdsAreValid()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockChildRepository = new Mock<IChildRepository>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockParentRepository = new Mock<IParentRepository>();

        var parent = Parent.Create(Guid.NewGuid(), "Mateo", "Quiceno", "david@gmail.com", "12345678mM*", "1234567890");
        var student = Child.Create(Guid.NewGuid(), "David", "Martinez", DateTime.Now.AddYears(-5), GradeLevel.PreKinder, Guid.NewGuid(), parent.Id);

        mockParentRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(parent);
        mockChildRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(student);
        mockUnitOfWork.Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(1));

        var service = new ChildService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockChildRepository.Object, mockParentRepository.Object);

        var message = new AddParentMessage
        {
            ChildId = student.Id,
            ParentId = parent.Id
        };

        // Act
        var result = await service.AddParent(message);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.Equal(student.Id, result.Value.ChildId);
        Assert.Equal(student.FirstName, result.Value.ChildFirstName);
        Assert.Equal(student.LastName, result.Value.ChildLastName);
        Assert.Equal(parent.Id, result.Value.ParentId);
        Assert.Equal(parent.FirstName, result.Value.ParentFirstName);
        Assert.Equal(parent.LastName, result.Value.ParentLastName);
    }

    [Fact]
    public async Task AddParent_ShouldReturnError_WhenChildNotFound()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockChildRepository = new Mock<IChildRepository>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockParentRepository = new Mock<IParentRepository>();

        mockChildRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync((Child?)null);

        var service = new ChildService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockChildRepository.Object, mockParentRepository.Object);

        var message = new AddParentMessage
        {
            ChildId = Guid.NewGuid(),
            ParentId = Guid.NewGuid()
        };

        // Act
        var result = await service.AddParent(message);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(Error.Children.NotFound.Code, result.FirstError.Code);
        Assert.Equal(Error.Children.NotFound.Message, result.FirstError.Message);
    }

    [Fact]
    public async Task AddParent_ShouldReturnError_WhenParentNotFound()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockChildRepository = new Mock<IChildRepository>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockParentRepository = new Mock<IParentRepository>();

        var child = Child.Create(Guid.NewGuid(), "David", "Martinez", DateTime.Now.AddYears(-5), GradeLevel.PreKinder, Guid.NewGuid(), Guid.NewGuid());
        mockParentRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync((Parent?)null);
        mockChildRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(child);

        var service = new ChildService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockChildRepository.Object, mockParentRepository.Object);


        var message = new AddParentMessage
        {
            ChildId = child.Id,
            ParentId = Guid.NewGuid()
        };

        // Act
        var result = await service.AddParent(message);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(Error.Children.NotFound.Code, result.FirstError.Code);
        Assert.Equal(Error.Children.NotFound.Message, result.FirstError.Message);
    }

    [Fact]
    public async Task AddParent_ShouldReturnFailureResult_WhenExceptionOccurs()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockChildRepository = new Mock<IChildRepository>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockParentRepository = new Mock<IParentRepository>();

        var parent = Parent.Create(Guid.NewGuid(), "Mateo", "Quiceno", "david@gmail.com", "12345678mM*", "1234567890");
        var student = Child.Create(Guid.NewGuid(), "Alice", "Johnson", DateTime.Now.AddYears(-5), GradeLevel.Kinder1, Guid.NewGuid(), parent.Id);

        mockParentRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(parent);
        mockChildRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(student);
        mockUnitOfWork.Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>())).Throws(new InvalidOperationException("Database error"));

        var service = new ChildService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockChildRepository.Object, mockParentRepository.Object);


        var message = new AddParentMessage
        {
            ChildId = student.Id,
            ParentId = parent.Id
        };

        // Act
        var result = await service.AddParent(message);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("InvalidOperationException", result.FirstError.Code);
        Assert.Equal("Database error", result.FirstError.Message);
    }
}