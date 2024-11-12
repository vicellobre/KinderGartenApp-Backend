using KinderGartenApp.Application.Validators;
using KinderGartenApp.Core.Entities;

namespace KinderGartenApp.Tests.Application.Validators.ChildValidators;

public partial class ChildValidatorTests
{
    [Fact]
    public void ChildValidator_Validate_ParentIdZero_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        var validChild = Child.Create(Guid.NewGuid(), "Mateo", "Quiceno", DateTime.Now.AddYears(-7), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, 0);

        //Act
        var childValidated = ChildValidator.Validate(validChild);

        //Assert
        Assert.False(childValidated.isValid);
        Assert.Equal("The parent ID cannot be less than or equal to 0.", childValidated.message);
    }

    [Fact]
    public void ChildValidator_Validate_ParentIdUnderZero_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        var validChild = Child.Create(Guid.NewGuid(), "Mateo", "Quiceno", DateTime.Now.AddYears(-7), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, -1);

        //Act
        var childValidated = ChildValidator.Validate(validChild);

        //Assert
        Assert.False(childValidated.isValid);
        Assert.Equal("The parent ID cannot be less than or equal to 0.", childValidated.message);
    }
}
