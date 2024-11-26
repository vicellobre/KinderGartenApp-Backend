using KinderGartenApp.Application.DTOs.Teachers.Register;
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
    public async Task Register_ShouldRegisterTeacher_WhenValidRequest()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockStudentRepository = new Mock<IChildRepository>();

        var message = new RegisterTeacherMessage
        {
            FirstName = "John",
            LastName = "Doe",
            GradeLevel = GradeLevel.PreKinder
        };

        var teacher = (Teacher?)message;

        mockTeacherRepository.Setup(repo => repo.Add(It.IsAny<Teacher>()));
        mockUnitOfWork.Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(1));

        var service = new TeacherService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockStudentRepository.Object);

        // Act
        var result = await service.Register(message);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.NotNull(teacher);
        Assert.Equal(teacher.FirstName, result.Value.FirstName);
        Assert.Equal(teacher.LastName, result.Value.LastName);
    }

    [Fact]
    public async Task Register_ShouldReturnError_WhenValidationFails()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockStudentRepository = new Mock<IChildRepository>();

        var message = new RegisterTeacherMessage
        {
            FirstName = "", // Nombre inválido
            LastName = "Doe",
            GradeLevel = GradeLevel.Kinder2
        };

        var service = new TeacherService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockStudentRepository.Object);

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
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockStudentRepository = new Mock<IChildRepository>();

        var message = new RegisterTeacherMessage
        {
            FirstName = "John",
            LastName = "Doe",
            GradeLevel = GradeLevel.Kinder1
        };

        var teacher = (Teacher?)message;

        mockTeacherRepository.Setup(repo => repo.Add(It.IsAny<Teacher>())).Throws(new InvalidOperationException("Database error"));

        var service = new TeacherService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockStudentRepository.Object);

        // Act
        var result = await service.Register(message);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("InvalidOperationException", result.FirstError.Code);
        Assert.Equal("Database error", result.FirstError.Message);
    }
}
