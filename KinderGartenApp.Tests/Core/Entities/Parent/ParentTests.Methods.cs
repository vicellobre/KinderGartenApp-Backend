using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Tests.Core.Entities.Parents;

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
        var password = "passwordmM*";
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
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "12345678mM*", "1234567890");
        Child child = Child.Create(Guid.NewGuid(), "Mateo", "Quiceno", DateTime.Now.AddYears(-7), GradeLevel.Kinder3, new Guid(), new Guid());

        //Act
        bool childAdded = parent.AddChild(child);

        //Assert
        Assert.NotNull(parent.Sons);
        Assert.Equal(child, parent.Sons.FirstOrDefault());
        Assert.True(childAdded);
    }

    [Fact]
    public void Parent_AddChild_CanAddMoreThanOneSon_ShouldAddChildrenCorrectly()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "12345678mM*", "1234567890");
        Child child1 = Child.Create(Guid.NewGuid(), "Mateo", "Quiceno", DateTime.Now.AddYears(-7), GradeLevel.Kinder3, new Guid(), new Guid());
        Child child2 = Child.Create(Guid.NewGuid(), "Theo", "Suarez", DateTime.Now.AddYears(-7), GradeLevel.Kinder2, new Guid(), new Guid());

        //Act
        bool childAdded1 = parent.AddChild(child1);
        bool childAdded2 = parent.AddChild(child2);

        //Assert
        Assert.NotNull(parent.Sons);
        Assert.Equal(child1, parent.Sons[0]);
        Assert.Equal(child2, parent.Sons[1]);
        Assert.True(childAdded1);
        Assert.True(childAdded2);
    }

    [Fact]
    public void Parent_AddChild_CantAddTheSameChildren_ShouldAddJustOneChild()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "12345678mM*", "1234567890");
        var id = Guid.NewGuid();
        Child child1 = Child.Create(id, "Mateo", "Quiceno", DateTime.Now.AddYears(-7), GradeLevel.Kinder3, new Guid(), new Guid());
        Child child2 = Child.Create(id, "Theo", "Suarez", DateTime.Now.AddYears(-7), GradeLevel.Kinder2, new Guid(), new Guid());

        //Act
        bool childAdded1 = parent.AddChild(child1);
        bool childAdded2 = parent.AddChild(child2);

        //Assert
        Assert.NotNull(parent.Sons);
        Assert.Single(parent.Sons);
        Assert.True(childAdded1);
        Assert.False(childAdded2);
    }

    [Fact]
    public void Parent_AddChild_CantAddNullChild_ShouldReturnFalse()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "12345678mM*", "1234567890");
        Child? child = null;

        //Act
        bool result = parent.AddChild(child!);

        //Assert
        Assert.NotNull(parent.Sons);
        Assert.False(result);
    }
}
