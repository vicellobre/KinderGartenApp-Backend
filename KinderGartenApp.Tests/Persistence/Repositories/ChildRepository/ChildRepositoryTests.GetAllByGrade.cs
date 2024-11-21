using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class ChildRepositoryTests
{
    [Fact]
    public async Task Can_Get_All_Children_By_GradeLevel()
    {
        // Arrange
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new ChildRepository(context);

        // Act
        var gradeLevel = GradeLevel.Kinder3;
        var children = await repository.GetAllByGradeLevel(gradeLevel);

        // Assert
        Assert.NotNull(children);
        Assert.All(children, c => Assert.Equal(gradeLevel, c.GradeLevel));
    }

    [Fact]
    public async Task Cant_Get_All_Children_By_GradeLevel_When_Empty()
    {
        // Arrange
        var context = TestContextFactory.Create();
        var repository = new ChildRepository(context);

        // Act
        var emptyGradeLevel = GradeLevel.PreKinder;
        var emptyChildren = await repository.GetAllByGradeLevel(emptyGradeLevel);

        // Assert
        Assert.NotNull(emptyChildren);
        Assert.Empty(emptyChildren);
    }
}
