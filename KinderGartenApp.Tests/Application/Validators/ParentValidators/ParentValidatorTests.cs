using KinderGartenApp.Application.Validators;
using KinderGartenApp.Core.Entities;

namespace KinderGartenApp.Tests.Application.Validators.ParentValidators;

public partial class ParentValidatorTests
{
    private const int maxNamesLenght = 50;
    private const int maxEmailLenght = 70;
    private const int minEmailLenght = 10;
    private const int maxPasswordLenght = 100;
    private const int minPasswordLenght = 8;

    [Fact]
    public void ParentValidator_Validate_IdealScenario_ShouldReturnTrue()
    {
        //Arrange
        var id = Guid.NewGuid();
        var firstName = "David";
        var lastName = "Martinez";
        var email = "david@gmail.com";
        var password = "password";
        var phone = "1234567890";
        Parent validParent = Parent.Create(id, firstName, lastName, email, password, phone);

        //Act
        var parentValidated = ParentValidator.Validate(validParent);

        //Assert
        Assert.True(parentValidated.isValid);
    }
}
