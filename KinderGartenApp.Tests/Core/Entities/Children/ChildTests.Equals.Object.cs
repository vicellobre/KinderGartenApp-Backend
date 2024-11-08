using KinderGartenApp.Core;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

public partial class ChildTests
{
    [Fact]
    public void Entity_Equals_WithObjectNull_ShouldReturnFalse()
    {
        //Arrange
        var id = Guid.NewGuid();
        var firstName = "Mateo";
        var lastName = "Quiceno";
        var birthDate = DateTime.Now.AddYears(-5);
        var gradeLevel = GradeLevel.Kinder1;
        var parentId = 123;

        //Act
        Child child = Child.Create(id, firstName, lastName, birthDate, gradeLevel, parentId);
        bool childEqualsWithNullChild = child.Equals(new object());

        //Assert
        Assert.False(childEqualsWithNullChild);
    }

    [Fact]
    public void Entity_Equals_DifferentObject_ShouldReturnFalse()
    {
        //Arrange
        var id = Guid.NewGuid();
        var firstName = "Mateo";
        var lastName = "Quiceno";
        var birthDate = DateTime.Now.AddYears(-5);
        var gradeLevel = GradeLevel.Kinder1;
        var parentId = 123;

        //Act
        Child child1 = Child.Create(id, firstName, lastName, birthDate, gradeLevel, parentId);
        string? differentObject = string.Empty;
        bool childEqualsWithSameChildId = child1.Equals(differentObject);

        //Assert
        Assert.False(childEqualsWithSameChildId);
    }

    [Fact]
    public void Entity_Equals_ObjectWithDifferentType_ShouldReturnFalse()
    {
        //Arrange
        var id = Guid.NewGuid();
        var firstName = "Mateo";
        var lastName = "Quiceno";
        var birthDate = DateTime.Now.AddYears(-5);
        var gradeLevel = GradeLevel.Kinder1;
        var parentId = 123;

        //Act
        Teacher objectWithDifferentType = Teacher.Create(id, firstName, lastName, gradeLevel);
        Child child = Child.Create(id, firstName, lastName, birthDate, gradeLevel, parentId);
        bool childEqualsWithDifferentObject = child.Equals((object) objectWithDifferentType);

        //Assert
        Assert.False(childEqualsWithDifferentObject);
    }

    [Fact]
    public void Entity_Equals_ObjectWithSameTypeAndChildId_ShouldReturnTrue()
    {
        //Arrange
        var id = Guid.NewGuid();
        var firstName1 = "Mateo";
        var lastName1 = "Quiceno";
        var birthDate1 = DateTime.Now.AddYears(-5);
        var gradeLevel1 = GradeLevel.Kinder1;
        var parentId1 = 123;

        var firstName2 = "David";
        var lastName2 = "Martinez";
        var birthDate2 = DateTime.Now.AddYears(-6);
        var gradeLevel2 = GradeLevel.Kinder2;
        var parentId2 = 321;

        //Act
        Child child1 = Child.Create(id, firstName1, lastName1, birthDate1, gradeLevel1, parentId1);
        Child child2 = Child.Create(id, firstName2, lastName2, birthDate2, gradeLevel2, parentId2);
        bool childEqualsWithSameChildId = child1.Equals((object)child2);

        //Assert
        Assert.True(childEqualsWithSameChildId);
    }
}