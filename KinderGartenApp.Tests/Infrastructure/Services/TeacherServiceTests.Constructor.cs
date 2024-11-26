using KinderGartenApp.Core.Contracts.Repositories;
using KinderGartenApp.Core.Contracts.UnitOfWorks;
using KinderGartenApp.Infrastructure.Services;
using Moq;

namespace KinderGartenApp.Tests.Infrastructure.Services;

public partial class TeacherServiceTests
{
    [Fact]
    public void Constructor_ShouldThrowArgumentNullException_WhenUnitOfWorkIsNull()
    {
        // Arrange
        IUnitOfWork? unitOfWork = null;
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockStudentRepository = new Mock<IChildRepository>();

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new TeacherService(unitOfWork, mockTeacherRepository.Object, mockStudentRepository.Object));
        Assert.Equal("unitOfWork", exception.ParamName);
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentNullException_WhenTeacherRepositoryIsNull()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        ITeacherRepository? teacherRepository = null;
        var mockStudentRepository = new Mock<IChildRepository>();

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new TeacherService(mockUnitOfWork.Object, teacherRepository, mockStudentRepository.Object));
        Assert.Equal("teacherRepository", exception.ParamName);
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentNullException_WhenStudentRepositoryIsNull()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        IChildRepository? studentRepository = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new TeacherService(mockUnitOfWork.Object, mockTeacherRepository.Object, studentRepository));
        Assert.Equal("studentRepository", exception.ParamName);
    }

    [Fact]
    public void Constructor_ShouldInitialize_WhenDependenciesAreNotNull()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockStudentRepository = new Mock<IChildRepository>();

        // Act
        var service = new TeacherService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockStudentRepository.Object);

        // Assert
        Assert.NotNull(service);
    }
}
