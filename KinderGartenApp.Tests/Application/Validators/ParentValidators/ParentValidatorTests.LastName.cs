using KinderGartenApp.Application.Validators;
using KinderGartenApp.Core.Entities;

namespace KinderGartenApp.Tests.Application.Validators.ParentValidators;

public partial class ParentValidatorTests
{
    [Fact]
    public void ParentValidator_Validate_LastNameEmpty_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent validParent = Parent.Create(Guid.NewGuid(), "David", "", "David@gmail.com", "12345678mM*", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(validParent);

        //Assert
        Assert.False(parentValidated.IsSuccess);
    }

    [Fact]
    public void ParentValidator_Validate_LastNameBlankSpaces_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent validParent = Parent.Create(Guid.NewGuid(), "David", "   ", "David@gmail.com", "12345678mM*", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(validParent);

        //Assert
        Assert.False(parentValidated.IsSuccess);
    }

    [Fact]
    public void ParentValidator_Validate_LastNameStartsWithBlankSpace_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent validParent = Parent.Create(Guid.NewGuid(), "David", " Martinez", "David@gmail.com", "12345678mM*", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(validParent);

        //Assert
        Assert.False(parentValidated.IsSuccess);
    }

    [Fact]
    public void ParentValidator_Validate_LastNameEndsWithBlankSpace_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent validParent = Parent.Create(Guid.NewGuid(), "David", "Martinez ", "David@gmail.com", "12345678mM*", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(validParent);

        //Assert
        Assert.False(parentValidated.IsSuccess);
    }

    [Fact]
    public void ParentValidator_Validate_LastNameLenghtMoreThenTheMax_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent validParent = Parent.Create(Guid.NewGuid(), "David", new string('a', maxNamesLenght + 1), "David@gmail.com", "12345678mM*", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(validParent);

        //Assert
        Assert.False(parentValidated.IsSuccess);
    }

    [Fact]
    public void ParentValidator_Validate_LastNameWithSpecialCharacters_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent validParent = Parent.Create(Guid.NewGuid(), "David", "M4rt1nez", "David@gmail.com", "12345678mM*", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(validParent);

        //Assert
        Assert.False(parentValidated.IsSuccess);
    }
}
