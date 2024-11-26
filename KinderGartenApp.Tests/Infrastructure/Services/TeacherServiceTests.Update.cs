using KinderGartenApp.Application.DTOs.Teachers.Update;
using KinderGartenApp.Core.Contracts.Repositories;
using KinderGartenApp.Core.Contracts.UnitOfWorks;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Errors;
using KinderGartenApp.Infrastructure.Services;
using Moq;

namespace KinderGartenApp.Tests.Infrastructure.Services;

public partial class TeacherServiceTests
{
    [Fact]
    public async Task Update_ShouldUpdateTeacher_WhenMessageIsValid()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockStudentRepository = new Mock<IChildRepository>();

        var existingTeacher = Teacher.Create(Guid.NewGuid(), "John", "Doe", GradeLevel.Kinder1);
        var message = new UpdateTeacherMessage
        {
            Id = existingTeacher.Id,
            FirstName = "Jane",
            LastName = "Smith",
            GradeLevel = GradeLevel.Kinder2
        };

        mockTeacherRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(existingTeacher);
        mockUnitOfWork.Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(1));


        var service = new TeacherService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockStudentRepository.Object);

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
    public async Task Update_ShouldReturnError_WhenTeacherNotFound()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockStudentRepository = new Mock<IChildRepository>();

        mockTeacherRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync((Teacher?)null);

        var service = new TeacherService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockStudentRepository.Object);

        var message = new UpdateTeacherMessage
        {
            Id = Guid.NewGuid(),
            FirstName = "Jane",
            LastName = "Smith",
            GradeLevel = GradeLevel.Kinder2
        };

        // Act
        var result = await service.Update(message);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("NotFound", result.FirstError.Code);
        Assert.Equal("Teacher not found", result.FirstError.Message);
    }

    [Fact]
    public async Task Update_ShouldReturnError_WhenValidationFails()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockStudentRepository = new Mock<IChildRepository>();

        var existingTeacher = Teacher.Create(Guid.NewGuid(), "John", "Doe", GradeLevel.Kinder1);
        var message = new UpdateTeacherMessage
        {
            Id = existingTeacher.Id,
            FirstName = "", // Nombre inválido
            LastName = "Smith",
            GradeLevel = GradeLevel.Kinder2
        };

        mockTeacherRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(existingTeacher);

        var service = new TeacherService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockStudentRepository.Object);

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
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockStudentRepository = new Mock<IChildRepository>();

        var existingTeacher = Teacher.Create(Guid.NewGuid(), "John", "Doe", GradeLevel.PreKinder);
        var message = new UpdateTeacherMessage
        {
            Id = existingTeacher.Id,
            FirstName = "Jane",
            LastName = "Smith",
            GradeLevel = GradeLevel.Kinder1
        };

        mockTeacherRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(existingTeacher);
        mockUnitOfWork.Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>())).Throws(new InvalidOperationException("Database error"));

        var service = new TeacherService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockStudentRepository.Object);

        // Act
        var result = await service.Update(message);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("InvalidOperationException", result.FirstError.Code);
        Assert.Equal("Database error", result.FirstError.Message);
    }
}
