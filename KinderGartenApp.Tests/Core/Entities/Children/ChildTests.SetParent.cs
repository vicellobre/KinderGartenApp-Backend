using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Tests.Core.Entities.Children;

public partial class ChildTests
{
    [Fact]
    public void Child_SetParent_WithValidParent_ShouldSetTheParentCorrectly()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "12345678", "1234567890");
        Child child = Child.Create(Guid.NewGuid(), "Mateo", "Quiceno", DateTime.Now.AddYears(-7), GradeLevel.Kinder3, new Guid(), new Guid());

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
        Child child = Child.Create(Guid.NewGuid(), "Mateo", "Quiceno", DateTime.Now.AddYears(-7), GradeLevel.Kinder3, new Guid(), new Guid());

        //Act
        bool parentSeted = child.SetParent(parent!);

        //Assert
        Assert.False(parentSeted);
        Assert.Null(child.Parent);
    }
}
