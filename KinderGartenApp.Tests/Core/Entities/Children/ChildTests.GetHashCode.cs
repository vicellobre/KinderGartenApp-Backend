using KinderGartenApp.Core;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Tests.Core.Entities.Children;

public partial class ChildTests
{
    [Fact]
    public void GetHashCode_ShouldReturnConsistentHashCode()
    {
        //Arrange
        var id = Guid.NewGuid();
        var firstName = "Mateo";
        var lastName = "Quiceno";
        var birthDate = DateTime.Now.AddYears(-7);
        var gradeLevel = GradeLevel.Kinder1;
        var parentId = 123;
        Child child = Child.Create(id, firstName, lastName, birthDate, gradeLevel, parentId);

        //Act
        var hashCode = child.GetHashCode();

        //Assert
        Assert.Equal(id.GetHashCode() * 41, hashCode);
    }

    [Fact]
    public void GetHashCode_WithDifferentIds_ShouldReturnDifferentHashCodes()
    {
        // Arrange
        var child1 = Child.Create(Guid.NewGuid(), "Mateo", "Quiceno", DateTime.Now.AddYears(-7), GradeLevel.Kinder3, 123);
        var child2 = Child.Create(Guid.NewGuid(), "David", "Martinez", DateTime.Now.AddYears(-7), GradeLevel.Kinder3, 123);

        // Act
        var hashCode1 = child1.GetHashCode();
        var hashCode2 = child2.GetHashCode();

        // Assert
        Assert.NotEqual(hashCode1, hashCode2);
    }
}
