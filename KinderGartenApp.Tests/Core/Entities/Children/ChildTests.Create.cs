using KinderGartenApp.Core;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

public partial class ChildTests
{
    [Fact]
    public void Child_Create_WithValidData_ShouldInitializePropetiesCorrectly()
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

        //Assert
        Assert.Equal(id, child.Id);
        Assert.Equal(firstName, child.FirstName);
        Assert.Equal(lastName, child.LastName);
        Assert.Equal(birthDate, child.BirthDate);
        Assert.Equal(gradeLevel, child.GradeLevel);
        Assert.Equal(parentId, child.ParentId);
    }
}
