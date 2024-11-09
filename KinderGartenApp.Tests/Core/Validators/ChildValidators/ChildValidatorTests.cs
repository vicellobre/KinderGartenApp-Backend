using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Validators;

namespace KinderGartenApp.Tests.Core.Validators.ChildValidators;

public partial class ChildValidatorTests
{
    [Fact]
    public void ChildValidator_Validate_IdealScenario_ShouldReturnTrue()
    {
        //Arrange
        var validChild = Child.Create(Guid.NewGuid(), "Mateo", "Quiceno", DateTime.Now.AddYears(-7), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, 123);

        //Act
        var childValidated = ChildValidator.Validate(validChild);

        //Assert
        Assert.True(childValidated.isValid);
    }
}
