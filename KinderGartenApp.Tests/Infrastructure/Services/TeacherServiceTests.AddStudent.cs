using KinderGartenApp.Application.DTOs.Teachers.AddStudent;
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
    public async Task AddStudent_ShouldAddStudent_WhenTeacherAndStudentIdsAreValidAndGradeLevelMatches()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockChildRepository = new Mock<IChildRepository>();

        var teacher = Teacher.Create(Guid.NewGuid(), "John", "Doe", GradeLevel.PreKinder);
        var student = Child.Create(Guid.NewGuid(), "Alice", "Johnson", DateTime.Now.AddYears(-5), GradeLevel.PreKinder, Guid.NewGuid(), teacher.Id);

        mockTeacherRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(teacher);
        mockChildRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(student);
        mockUnitOfWork.Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(1));

        var service = new TeacherService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockChildRepository.Object);

        var message = new AddStudentMessage
        {
            TeacherId = teacher.Id,
            StudentId = student.Id
        };

        // Act
        var result = await service.AddStudent(message);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.Equal(student.Id, result.Value.StudentId);
        Assert.Equal(student.FirstName, result.Value.StudentFirstName);
        Assert.Equal(student.LastName, result.Value.StudentLastName);
        Assert.Equal(teacher.Id, result.Value.TeacherId);
        Assert.Equal(teacher.FirstName, result.Value.TeacherFirstName);
        Assert.Equal(teacher.LastName, result.Value.TeacherLastName);
    }

    [Fact]
    public async Task AddStudent_ShouldReturnError_WhenTeacherNotFound()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockChildRepository = new Mock<IChildRepository>();

        mockTeacherRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync((Teacher?)null);

        var service = new TeacherService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockChildRepository.Object);

        var message = new AddStudentMessage
        {
            TeacherId = Guid.NewGuid(),
            StudentId = Guid.NewGuid()
        };

        // Act
        var result = await service.AddStudent(message);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(Error.Teacher.NotFound.Code, result.FirstError.Code);
        Assert.Equal(Error.Teacher.NotFound.Message, result.FirstError.Message);
    }

    [Fact]
    public async Task AddStudent_ShouldReturnError_WhenStudentNotFound()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockChildRepository = new Mock<IChildRepository>();

        var teacher = Teacher.Create(Guid.NewGuid(), "John", "Doe", GradeLevel.Kinder1);
        mockTeacherRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(teacher);
        mockChildRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync((Child?)null);

        var service = new TeacherService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockChildRepository.Object);

        var message = new AddStudentMessage
        {
            TeacherId = teacher.Id,
            StudentId = Guid.NewGuid()
        };

        // Act
        var result = await service.AddStudent(message);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(Error.Child.NotFound.Code, result.FirstError.Code);
        Assert.Equal(Error.Child.NotFound.Message, result.FirstError.Message);
    }

    [Fact]
    public async Task AddStudent_ShouldReturnError_WhenGradeLevelDoesNotMatch()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockChildRepository = new Mock<IChildRepository>();

        var teacher = Teacher.Create(Guid.NewGuid(), "John", "Doe", GradeLevel.Kinder2);
        var student = Child.Create(Guid.NewGuid(), "Alice", "Johnson", DateTime.Now.AddYears(-5), GradeLevel.Kinder3, Guid.NewGuid(), teacher.Id);

        mockTeacherRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(teacher);
        mockChildRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(student);

        var service = new TeacherService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockChildRepository.Object);

        var message = new AddStudentMessage
        {
            TeacherId = teacher.Id,
            StudentId = student.Id
        };

        // Act
        var result = await service.AddStudent(message);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(Error.Teacher.GradeLevelMismatch(teacher.GradeLevel).Code, result.FirstError.Code);
        Assert.Equal(Error.Teacher.GradeLevelMismatch(teacher.GradeLevel).Message, result.FirstError.Message);
    }

    [Fact]
    public async Task AddStudent_ShouldReturnFailureResult_WhenExceptionOccurs()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockChildRepository = new Mock<IChildRepository>();

        var teacher = Teacher.Create(Guid.NewGuid(), "John", "Doe", GradeLevel.Kinder1);
        var student = Child.Create(Guid.NewGuid(), "Alice", "Johnson", DateTime.Now.AddYears(-5), GradeLevel.Kinder1, Guid.NewGuid(), teacher.Id);

        mockTeacherRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(teacher);
        mockChildRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(student);
        mockUnitOfWork.Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>())).Throws(new InvalidOperationException("Database error"));

        var service = new TeacherService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockChildRepository.Object);

        var message = new AddStudentMessage
        {
            TeacherId = teacher.Id,
            StudentId = student.Id
        };

        // Act
        var result = await service.AddStudent(message);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("InvalidOperationException", result.FirstError.Code);
        Assert.Equal("Database error", result.FirstError.Message);
    }
}