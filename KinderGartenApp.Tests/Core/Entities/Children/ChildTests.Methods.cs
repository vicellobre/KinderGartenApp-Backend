using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Tests.Core.Entities.Children;

public partial class ChildTests
{
    [Fact]
    public void Child_Create_WithValidData_ShouldInitializePropetiesCorrectly()
    {
        //Arrange
        var id = Guid.NewGuid();
        var firstName = "Mateo";
        var lastName = "Quiceno";
        var birthDate = DateTime.Now.AddYears(-7);
        var gradeLevel = GradeLevel.Kinder1;
        var parentId = 123;

        //Act
        Child child = Child.Create(id, firstName, lastName, birthDate, gradeLevel, parentId);

        //Assert
        Assert.Equal(id, child.Id);
        Assert.Equal(firstName, child.FirstName);
        Assert.Equal(lastName, child.LastName);
        Assert.Equal(birthDate, child.BirthDate);
        Assert.Equal(gradeLevel, child.GradeLevel);
        Assert.Equal(parentId, child.ParentId);
    }

    [Fact]
    public void Child_SetParent_WithValidParent_ShouldSetTheParentCorrectly()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "12345678", "1234567890");
        Child child = Child.Create(Guid.NewGuid(), "Mateo", "Quiceno", DateTime.Now.AddYears(-7), GradeLevel.Kinder3, 123);

        //Act
        bool parentSeted = child.SetParent(parent);

        //Assert
        Assert.True(parentSeted);
        Assert.Equal(parent, child.Parent);
    }

    [Fact]
    public void Child_SetParent_WithInvalidParent_ShouldNotSetTheParentAndReturnFalse()
    {
        //Arrange
        Parent? parent = null;
        Child child = Child.Create(Guid.NewGuid(), "Mateo", "Quiceno", DateTime.Now.AddYears(-7), GradeLevel.Kinder3, 123);

        //Act
        bool parentSeted = child.SetParent(parent!);

        //Assert
        Assert.False(parentSeted);
        Assert.Null(child.Parent);
    }
}
