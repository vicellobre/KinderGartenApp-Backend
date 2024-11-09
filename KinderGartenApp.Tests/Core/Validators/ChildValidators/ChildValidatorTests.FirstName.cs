using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Validators;

namespace KinderGartenApp.Tests.Core.Validators.ChildValidators;

public partial class ChildValidatorTests
{
    [Fact]
    public void ChildValidator_Validate_FirstNameNull_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        var validChild = Child.Create(Guid.NewGuid(), "", "Quiceno", DateTime.Now.AddYears(-7), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, 123);

        //Act
        var childValidated = ChildValidator.Validate(validChild);

        //Assert
        Assert.False(childValidated.isValid);
        Assert.Equal("The name cannot be empty or start or end with a blank space.", childValidated.message);
    }

    [Fact]
    public void ChildValidator_Validate_FirstNameWithWhiteSpace_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        var validChild = Child.Create(Guid.NewGuid(), "   ", "Quiceno", DateTime.Now.AddYears(-7), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, 123);

        //Act
        var childValidated = ChildValidator.Validate(validChild);

        //Assert
        Assert.False(childValidated.isValid);
        Assert.Equal("The name cannot be empty or start or end with a blank space.", childValidated.message);
    }

    [Fact]
    public void ChildValidator_Validate_FirstNameWithFirstSpaceBlank_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        var validChild = Child.Create(Guid.NewGuid(), " Mateo", "Quiceno", DateTime.Now.AddYears(-7), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, 123);

        //Act
        var childValidated = ChildValidator.Validate(validChild);

        //Assert
        Assert.False(childValidated.isValid);
        Assert.Equal("The name cannot be empty or start or end with a blank space.", childValidated.message);
    }

    [Fact]
    public void ChildValidator_Validate_FirstNameWithLastSpaceBlank_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        var validChild = Child.Create(Guid.NewGuid(), "Mateo ", "Quiceno", DateTime.Now.AddYears(-7), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, 123);

        //Act
        var childValidated = ChildValidator.Validate(validChild);

        //Assert
        Assert.False(childValidated.isValid);
        Assert.Equal("The name cannot be empty or start or end with a blank space.", childValidated.message);
    }

    [Fact]
    public void ChildValidator_Validate_FirstNameLenghtMoreThenTheMax_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        var validChild = Child.Create(Guid.NewGuid(), new string('a', 51), "Quiceno", DateTime.Now.AddYears(-7), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, 123);

        //Act
        var childValidated = ChildValidator.Validate(validChild);

        //Assert
        Assert.False(childValidated.isValid);
        Assert.Equal("The name cannot exceed 50 characters.", childValidated.message);
    }

    [Fact]
    public void ChildValidator_Validate_FirstNameWithSpecialCharacters_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        var validChild = Child.Create(Guid.NewGuid(), "Mªtº*+", "Quiceno", DateTime.Now.AddYears(-7), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, 123);

        //Act
        var childValidated = ChildValidator.Validate(validChild);

        //Assert
        Assert.False(childValidated.isValid);
        Assert.Equal("The name cannot contain special characters.", childValidated.message);
    }
}
