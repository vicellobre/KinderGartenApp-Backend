using KinderGartenApp.Core.Entities;

namespace KinderGartenApp.Tests.Core.Entities.Parents;

public partial class ParentTests
{
    [Fact]
    public void GetHashCode_ShouldReturnConsistentHashCode()
    {
        //Arrange
        var id = Guid.NewGuid();
        var firstName = "David";
        var lastName = "Martinez";
        var email = "david@gmail.com";
        var password = "passwordmM*123456";
        var phone = "1234567890";
        Parent parent = Parent.Create(id, firstName, lastName, email, password, phone);

        //Act
        var hashCode = parent.GetHashCode();

        //Assert
        Assert.Equal(id.GetHashCode() * 41, hashCode);
    }

    [Fact]
    public void GetHashCode_WithDifferentIds_ShouldReturnDifferentHashCodes()
    {
        // Arrange
        Parent parent1 = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "12345678mM*", "1234567890");
        Parent parent2 = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "12345678mM*", "1234567890");

        // Act
        var hashCode1 = parent1.GetHashCode();
        var hashCode2 = parent2.GetHashCode();

        // Assert
        Assert.NotEqual(hashCode1, hashCode2);
    }
}
