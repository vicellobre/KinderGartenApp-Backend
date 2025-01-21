using KinderGartenApp.Application.DTOs.Children.AddTeacher;
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
    public async Task AddTeacher_ShouldAddTeacher_WhenChildAndTeacherIdsAreValid()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockChildRepository = new Mock<IChildRepository>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockParentRepository = new Mock<IParentRepository>();

        var teacher = Teacher.Create(Guid.NewGuid(), "Mateo", "Quiceno", GradeLevel.PreKinder);
        var student = Child.Create(Guid.NewGuid(), "David", "Martinez", DateTime.Now.AddYears(-5), GradeLevel.PreKinder, Guid.NewGuid(), teacher.Id);

        mockTeacherRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(teacher);
        mockChildRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(student);
        mockUnitOfWork.Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(1));

        var service = new ChildService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockChildRepository.Object, mockParentRepository.Object);

        var message = new AddTeacherMessage
        {
            ChildId = student.Id,
            TeacherId = teacher.Id
        };

        // Act
        var result = await service.AddTeacher(message);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.Equal(student.Id, result.Value.ChildId);
        Assert.Equal(student.FirstName, result.Value.ChildFirstName);
        Assert.Equal(student.LastName, result.Value.ChildLastName);
        Assert.Equal(teacher.Id, result.Value.TeacherId);
        Assert.Equal(teacher.FirstName, result.Value.TeacherFirstName);
        Assert.Equal(teacher.LastName, result.Value.TeacherLastName);
    }

    [Fact]
    public async Task AddTeacher_ShouldReturnError_WhenChildNotFound()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockChildRepository = new Mock<IChildRepository>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockParentRepository = new Mock<IParentRepository>();

        mockChildRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync((Child?)null);

        var service = new ChildService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockChildRepository.Object, mockParentRepository.Object);

        var message = new AddTeacherMessage
        {
            ChildId = Guid.NewGuid(),
            TeacherId = Guid.NewGuid()
        };

        // Act
        var result = await service.AddTeacher(message);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(Error.Children.NotFound.Code, result.FirstError.Code);
        Assert.Equal(Error.Children.NotFound.Message, result.FirstError.Message);
    }

    [Fact]
    public async Task AddTeacher_ShouldReturnError_WhenTeacherNotFound()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockChildRepository = new Mock<IChildRepository>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockParentRepository = new Mock<IParentRepository>();

        var child = Child.Create(Guid.NewGuid(), "David", "Martinez", DateTime.Now.AddYears(-5), GradeLevel.PreKinder, Guid.NewGuid(), Guid.NewGuid());
        mockTeacherRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync((Teacher?)null);
        mockChildRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(child);

        var service = new ChildService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockChildRepository.Object, mockParentRepository.Object);


        var message = new AddTeacherMessage
        {
            ChildId = child.Id,
            TeacherId = Guid.NewGuid()
        };

        // Act
        var result = await service.AddTeacher(message);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(Error.Children.NotFound.Code, result.FirstError.Code);
        Assert.Equal(Error.Children.NotFound.Message, result.FirstError.Message);
    }

    [Fact]
    public async Task AddTeacher_ShouldReturnFailureResult_WhenExceptionOccurs()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockChildRepository = new Mock<IChildRepository>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockParentRepository = new Mock<IParentRepository>();

        var teacher = Teacher.Create(Guid.NewGuid(), "John", "Doe", GradeLevel.Kinder1);
        var student = Child.Create(Guid.NewGuid(), "Alice", "Johnson", DateTime.Now.AddYears(-5), GradeLevel.Kinder1, Guid.NewGuid(), teacher.Id);

        mockTeacherRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(teacher);
        mockChildRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(student);
        mockUnitOfWork.Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>())).Throws(new InvalidOperationException("Database error"));

        var service = new ChildService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockChildRepository.Object, mockParentRepository.Object);


        var message = new AddTeacherMessage
        {
            ChildId = student.Id,
            TeacherId = teacher.Id
        };

        // Act
        var result = await service.AddTeacher(message);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("InvalidOperationException", result.FirstError.Code);
        Assert.Equal("Database error", result.FirstError.Message);
    }
}