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
}
