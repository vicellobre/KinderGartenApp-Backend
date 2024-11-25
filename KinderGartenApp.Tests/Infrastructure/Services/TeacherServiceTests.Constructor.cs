using KinderGartenApp.Core.Contracts.Repositories;
using KinderGartenApp.Core.Contracts.UnitOfWorks;
using KinderGartenApp.Infrastructure.Services;
using Moq;

namespace KinderGartenApp.Tests.Infrastructure.Services;

public class TeacherServiceTests_Constructor
{
    [Fact]
    public void Constructor_ShouldThrowArgumentNullException_WhenUnitOfWorkIsNull()
    {
        // Arrange
        IUnitOfWork? unitOfWork = null;
        var mockTeacherRepository = new Mock<ITeacherRepository>();

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new TeacherService(unitOfWork, mockTeacherRepository.Object));
        Assert.Equal("unitOfWork", exception.ParamName);
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentNullException_WhenTeacherRepositoryIsNull()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        ITeacherRepository? teacherRepository = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new TeacherService(mockUnitOfWork.Object, teacherRepository));
        Assert.Equal("teacherRepository", exception.ParamName);
    }

    [Fact]
    public void Constructor_ShouldInitialize_WhenDependenciesAreNotNull()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockTeacherRepository = new Mock<ITeacherRepository>();

        // Act
        var service = new TeacherService(mockUnitOfWork.Object, mockTeacherRepository.Object);

        // Assert
        Assert.NotNull(service);
    }
}
