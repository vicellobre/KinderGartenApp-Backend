using KinderGartenApp.Core.Entities;

namespace KinderGartenApp.Tests.Core.Entities.Parents;

public partial class ParentTests
{
    [Fact]
    public void Entity_DifferentOperator_ParentsWithTheSameID_ShouldReturnFalse()
    {
        //Arrange
        var id = Guid.NewGuid();
        Parent parent1 = Parent.Create(id, "David", "Martinez", "David@gmail.com", "1234", "1234567890");
        Parent parent2 = Parent.Create(id, "Omar", "Montenegro", "Omar@Gmail.com", "123456", "0987654321");

        //Act
        bool parent1EqualsToParent2 = parent1 != parent2;

        //Assert
        Assert.False(parent1EqualsToParent2);
    }

    [Fact]
    public void Entity_DifferentOperator_ParentsWithDifferentID_ShouldReturnTrue()
    {
        //Arrange
        Parent parent1 = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "1234", "1234567890");
        Parent parent2 = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "1234", "1234567890");

        //Act
        bool parent1EqualsToParent2 = parent1 != parent2;

        //Assert
        Assert.True(parent1EqualsToParent2);
    }
}
