﻿using KinderGartenApp.Application.DTOs.Teachers.Get;
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
    public async Task Get_ShouldReturnTeacher_WhenIdIsValid()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockStudentRepository = new Mock<IChildRepository>();

        var teacher = Teacher.Create(Guid.NewGuid(), "John", "Doe", GradeLevel.PreKinder);
        mockTeacherRepository.Setup(repo => repo.GetByIdAsNoTrackingAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(teacher);

        var service = new TeacherService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockStudentRepository.Object);

        var message = new GetTeacherMessage { Id = teacher.Id };

        // Act
        var result = await service.Get(message);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.Equal(teacher.Id, result.Value.Id);
        Assert.Equal(teacher.FirstName, result.Value.FirstName);
        Assert.Equal(teacher.LastName, result.Value.LastName);
        Assert.Equal(teacher.GradeLevel, result.Value.GradeLevel);
    }

    [Fact]
    public async Task Get_ShouldReturnError_WhenTeacherNotFound()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockStudentRepository = new Mock<IChildRepository>();

        mockTeacherRepository.Setup(repo => repo.GetByIdAsNoTrackingAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync((Teacher?)null);

        var service = new TeacherService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockStudentRepository.Object);

        var message = new GetTeacherMessage { Id = Guid.NewGuid() };

        // Act
        var result = await service.Get(message);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(Error.Teacher.NotFound.Code, result.FirstError.Code);
        Assert.Equal(Error.Teacher.NotFound.Message, result.FirstError.Message);
    }

    [Fact]
    public async Task Get_ShouldReturnFailureResult_WhenExceptionOccurs()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockStudentRepository = new Mock<IChildRepository>();

        mockTeacherRepository.Setup(repo => repo.GetByIdAsNoTrackingAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).Throws(new InvalidOperationException("Database error"));

        var service = new TeacherService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockStudentRepository.Object);

        var message = new GetTeacherMessage { Id = Guid.NewGuid() };

        // Act
        var result = await service.Get(message);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("InvalidOperationException", result.FirstError.Code);
        Assert.Equal("Database error", result.FirstError.Message);
    }
}
