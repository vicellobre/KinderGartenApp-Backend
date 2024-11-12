using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Tests.Core.Entities.Children;

public partial class ChildTests
{
    [Fact]
    public void Entity_Equals_WithEntityNull_ShouldReturnFalse()
    {
        //Arrange
        var id = Guid.NewGuid();
        var firstName = "Mateo";
        var lastName = "Quiceno";
        var birthDate = DateTime.Now.AddYears(-7);
        var gradeLevel = GradeLevel.Kinder1;

        //Act
        Child? nullChild = null;
        Child child = Child.Create(id, firstName, lastName, birthDate, gradeLevel, new Guid(), new Guid());
        bool childEqualsWithNullChild = child.Equals(nullChild);

        //Assert
        Assert.False(childEqualsWithNullChild);
    }

    [Fact]
    public void Entity_Equals_EntityWithDifferentType_ShouldReturnFalse()
    {
        //Arrange
        var id = Guid.NewGuid();
        var firstName = "Mateo";
        var lastName = "Quiceno";
        var birthDate = DateTime.Now.AddYears(-7);
        var gradeLevel = GradeLevel.Kinder1;

        //Act
        Teacher entityWithDifferentType = Teacher.Create(id, firstName, lastName, gradeLevel);
        Child child = Child.Create(id, firstName, lastName, birthDate, gradeLevel, new Guid(), new Guid());
        bool childEqualsWithDifferentEntity = child.Equals(entityWithDifferentType);

        //Assert
        Assert.False(childEqualsWithDifferentEntity);
    }

    [Fact]
    public void Entity_Equals_EntityWithSameTypeAndChildId_ShouldReturnTrue()
    {
        //Arrange
        var id = Guid.NewGuid();
        var firstName1 = "Mateo";
        var lastName1 = "Quiceno";
        var birthDate1 = DateTime.Now.AddYears(-7);
        var gradeLevel1 = GradeLevel.Kinder1;

        var firstName2 = "David";
        var lastName2 = "Martinez";
        var birthDate2 = DateTime.Now.AddYears(-8);
        var gradeLevel2 = GradeLevel.Kinder2;

        //Act
        Child child1 = Child.Create(id, firstName1, lastName1, birthDate1, gradeLevel1, new Guid(), new Guid());
        Child child2 = Child.Create(id, firstName2, lastName2, birthDate2, gradeLevel2, new Guid(), new Guid());
        bool childEqualsWithSameChildId = child1.Equals(child2);

        //Assert
        Assert.True(childEqualsWithSameChildId);
    }
}
