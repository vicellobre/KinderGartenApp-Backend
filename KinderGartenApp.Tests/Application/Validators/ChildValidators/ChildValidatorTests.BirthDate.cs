using KinderGartenApp.Application.Validators;
using KinderGartenApp.Core.Entities;

namespace KinderGartenApp.Tests.Application.Validators.ChildValidators;

public partial class ChildValidatorTests
{
    [Fact]
    public void ChildValidator_Validate_FutureBirthDate_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        var validChild = Child.Create(Guid.NewGuid(), "Mateo", "Quiceno", DateTime.Today.AddYears(-2), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, new Guid(), new Guid());

        //Act
        var result = ChildValidator.Validate(validChild);

        //Assert
        Assert.False(result.IsSuccess);
    }
}

