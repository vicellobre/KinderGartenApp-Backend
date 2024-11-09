using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Validators;

namespace KinderGartenApp.Tests.Core.Validators.ChildValidators;

public partial class ChildValidatorTests
{
    [Fact]
    public void ChildValidator_Validate_FutureBirthDate_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        var validChild = Child.Create(Guid.NewGuid(), "Mateo", "Quiceno", DateTime.Today.AddYears(-2), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, 123);

        //Act
        var childValidated = ChildValidator.Validate(validChild);

        //Assert
        Assert.False(childValidated.isValid);
        Assert.Equal("The birth date cannot be less than 6 years ago.", childValidated.message);
    }
}

