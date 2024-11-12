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
        var parentId = new Guid();
        var teacherId = new Guid();

        //Act
        Child child = Child.Create(id, firstName, lastName, birthDate, gradeLevel, parentId, teacherId);

        //Assert
        Assert.Equal(id, child.Id);
        Assert.Equal(firstName, child.FirstName);
        Assert.Equal(lastName, child.LastName);
        Assert.Equal(birthDate, child.BirthDate);
        Assert.Equal(gradeLevel, child.GradeLevel);
        Assert.Equal(parentId, child.ParentId);
        Assert.Equal(teacherId, child.TeacherId);
    }

    [Fact]
    public void Child_Create_WithValidData_ShouldInitializePropetiesCorrectly_And_NullTeacher()
    {
        //Arrange
        var id = Guid.NewGuid();
        var firstName = "Mateo";
        var lastName = "Quiceno";
        var birthDate = DateTime.Now.AddYears(-7);
        var gradeLevel = GradeLevel.Kinder1;
        var parentId = new Guid();
        var teacherId = new Guid();

        //Act
        Child child = Child.Create(id, firstName, lastName, birthDate, gradeLevel, parentId, teacherId);
        child.Teacher = null;

        //Assert
        Assert.Equal(id, child.Id);
        Assert.Equal(firstName, child.FirstName);
        Assert.Equal(lastName, child.LastName);
        Assert.Equal(birthDate, child.BirthDate);
        Assert.Equal(gradeLevel, child.GradeLevel);
        Assert.Equal(parentId, child.ParentId);
        Assert.Equal(teacherId, child.TeacherId);
        Assert.Null(child.Teacher);
    }
}