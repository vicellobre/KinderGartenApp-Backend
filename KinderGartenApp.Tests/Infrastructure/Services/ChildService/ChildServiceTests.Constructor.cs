using KinderGartenApp.Core.Contracts.Repositories;
using KinderGartenApp.Core.Contracts.UnitOfWorks;
using KinderGartenApp.Infrastructure.Services;
using Moq;

namespace KinderGartenApp.Tests.Infrastructure.Services;

public partial class ChildServiceTests
{
    [Fact]
    public void Constructor_ShouldThrowArgumentNullException_WhenUnitOfWorkIsNull()
    {
        // Arrange
        IUnitOfWork? unitOfWork = null;
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockStudentRepository = new Mock<IChildRepository>();
        var mockParentRepository = new Mock<IParentRepository>();

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new ChildService(unitOfWork, mockTeacherRepository.Object, mockStudentRepository.Object, mockParentRepository.Object));
        Assert.Equal("unitOfWork", exception.ParamName);
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentNullException_WhenTeacherRepositoryIsNull()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        ITeacherRepository? teacherRepository = null;
        var mockStudentRepository = new Mock<IChildRepository>();
        var mockParentRepository = new Mock<IParentRepository>();

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new ChildService(mockUnitOfWork.Object, teacherRepository, mockStudentRepository.Object, mockParentRepository.Object));
        Assert.Equal("teacherRepository", exception.ParamName);
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentNullException_WhenStudentRepositoryIsNull()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockParentRepository = new Mock<IParentRepository>();
        IChildRepository? studentRepository = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new ChildService(mockUnitOfWork.Object, mockTeacherRepository.Object, studentRepository, mockParentRepository.Object));
        Assert.Equal("studentRepository", exception.ParamName);
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentNullException_WhenParentRepositoryIsNull()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockStudentRepository = new Mock<IChildRepository>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        IParentRepository? parentRepository = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new ChildService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockStudentRepository.Object, parentRepository));
        Assert.Equal("parentRepository", exception.ParamName);
    }

    [Fact]
    public void Constructor_ShouldInitialize_WhenDependenciesAreNotNull()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();
        var mockStudentRepository = new Mock<IChildRepository>();
        var mockParentRepository = new Mock<IParentRepository>();

        // Act
        var service = new ChildService(mockUnitOfWork.Object, mockTeacherRepository.Object, mockStudentRepository.Object, mockParentRepository.Object);

        // Assert
        Assert.NotNull(service);
    }
}
