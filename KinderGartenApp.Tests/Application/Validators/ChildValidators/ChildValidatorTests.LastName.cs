using KinderGartenApp.Application.Validators;
using KinderGartenApp.Core.Entities;

namespace KinderGartenApp.Tests.Application.Validators.ChildValidators;

public partial class ChildValidatorTests
{
    [Fact]
    public void ChildValidator_Validate_LastNameNull_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        var validChild = Child.Create(Guid.NewGuid(), "Mateo", "", DateTime.Now.AddYears(-7), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, new Guid(), new Guid());

        //Act
        var childValidated = ChildValidator.Validate(validChild);

        //Assert
        Assert.False(childValidated.isValid);
        Assert.Equal("The last name cannot be empty or start or end with a blank space.", childValidated.message);
    }

    [Fact]
    public void ChildValidator_Validate_LastNameWithWhiteSpace_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        var validChild = Child.Create(Guid.NewGuid(), "Mateo", "   ", DateTime.Now.AddYears(-7), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, new Guid(), new Guid());

        //Act
        var childValidated = ChildValidator.Validate(validChild);

        //Assert
        Assert.False(childValidated.isValid);
        Assert.Equal("The last name cannot be empty or start or end with a blank space.", childValidated.message);
    }

    [Fact]
    public void ChildValidator_Validate_LastNameWithFirstSpaceBlank_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        var validChild = Child.Create(Guid.NewGuid(), "Mateo", " Quiceno", DateTime.Now.AddYears(-7), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, new Guid(), new Guid());

        //Act
        var childValidated = ChildValidator.Validate(validChild);

        //Assert
        Assert.False(childValidated.isValid);
        Assert.Equal("The last name cannot be empty or start or end with a blank space.", childValidated.message);
    }

    [Fact]
    public void ChildValidator_Validate_LastNameWithLastSpaceBlank_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        var validChild = Child.Create(Guid.NewGuid(), "Mateo", "Quiceno ", DateTime.Now.AddYears(-7), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, new Guid(), new Guid());

        //Act
        var childValidated = ChildValidator.Validate(validChild);

        //Assert
        Assert.False(childValidated.isValid);
        Assert.Equal("The last name cannot be empty or start or end with a blank space.", childValidated.message);
    }

    [Fact]
    public void ChildValidator_Validate_LastNameLenghtMoreThenTheMax_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        var validChild = Child.Create(Guid.NewGuid(), "Mateo", new string('a', 51), DateTime.Now.AddYears(-7), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, new Guid(), new Guid());

        //Act
        var childValidated = ChildValidator.Validate(validChild);

        //Assert
        Assert.False(childValidated.isValid);
        Assert.Equal("The last name cannot exceed 50 characters.", childValidated.message);
    }

    [Fact]
    public void ChildValidator_Validate_LastNameWithSpecialCharacters_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        var validChild = Child.Create(Guid.NewGuid(), "Mateo", "Qªtº*+", DateTime.Now.AddYears(-7), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, new Guid(), new Guid());

        //Act
        var childValidated = ChildValidator.Validate(validChild);

        //Assert
        Assert.False(childValidated.isValid);
        Assert.Equal("The last name cannot contain special characters.", childValidated.message);
    }
}
