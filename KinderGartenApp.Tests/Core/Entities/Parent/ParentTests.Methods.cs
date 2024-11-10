using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Tests.Core.Entities;

public partial class ParentTests
{
    [Fact]
    public void Parent_Create_WithValidData_ShouldInitializePropetiesCorrectly()
    {
        //Arrange
        var id = Guid.NewGuid();
        var firstName = "David";
        var lastName = "Martinez";
        var email = "david@gmail.com";
        var password = "password";
        var phone = "1234567890";


        //Act
        Parent parent = Parent.Create(id, firstName, lastName, email, password, phone);

        //Assert
        Assert.Equal(id, parent.Id);
        Assert.Equal(firstName, parent.FirstName);
        Assert.Equal(lastName, parent.LastName);
        Assert.Equal(email, parent.Email);
        Assert.Equal(password, parent.Password);
        Assert.Equal(phone, parent.Phone);
    }

    [Fact]
    public void Parent_AddChild_WithValidData_ShouldAddChildrenCorrectly()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "1234", "1234567890");
        Child child = Child.Create(Guid.NewGuid(), "Mateo", "Quiceno", DateTime.Now.AddYears(-7), GradeLevel.Kinder3, 123);

        //Act
        parent.AddChild(child);

        //Assert
        Assert.NotNull(parent.Sons);
        Assert.Equal(child, parent.Sons.FirstOrDefault());
    }

    [Fact]
    public void Parent_AddChild_CanAddMoreThanOneSon_ShouldAddChildrenCorrectly()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "1234", "1234567890");
        Child child1 = Child.Create(Guid.NewGuid(), "Mateo", "Quiceno", DateTime.Now.AddYears(-7), GradeLevel.Kinder3, 123);
        Child child2 = Child.Create(Guid.NewGuid(), "Theo", "Suarez", DateTime.Now.AddYears(-7), GradeLevel.Kinder2, 1523);

        //Act
        parent.AddChild(child1);
        parent.AddChild(child2);

        //Assert
        Assert.NotNull(parent.Sons);
        Assert.Equal(child1, parent.Sons[0]);
        Assert.Equal(child2, parent.Sons[1]);
    }

    [Fact]
    public void Parent_AddChild_CantAddTheSameChildren_ShouldAddJustOneChild()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "1234", "1234567890");
        var id = Guid.NewGuid();
        Child child1 = Child.Create(id, "Mateo", "Quiceno", DateTime.Now.AddYears(-7), GradeLevel.Kinder3, 123);
        Child child2 = Child.Create(id, "Theo", "Suarez", DateTime.Now.AddYears(-7), GradeLevel.Kinder2, 1523);

        //Act
        parent.AddChild(child1);
        parent.AddChild(child2);

        //Assert
        Assert.NotNull(parent.Sons);
        Assert.Single(parent.Sons);
    }
}
