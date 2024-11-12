using KinderGartenApp.Application.Validators;
using KinderGartenApp.Core.Entities;

namespace KinderGartenApp.Tests.Application.Validators.ParentValidators;

public partial class ParentValidatorTests
{
    [Fact]
    public void ParentValidator_Validate_FirstNameEmpty_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent validParent = Parent.Create(Guid.NewGuid(), "", "Martinez", "David@gmail.com", "12345678", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(validParent);

        //Assert
        Assert.False(parentValidated.isValid);
        Assert.Equal("The name cannot be empty or start or end with a blank space.", parentValidated.message);
    }

    [Fact]
    public void ParentValidator_Validate_FirstNameBlankSpaces_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent validParent = Parent.Create(Guid.NewGuid(), "   ", "Martinez", "David@gmail.com", "12345678", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(validParent);

        //Assert
        Assert.False(parentValidated.isValid);
        Assert.Equal("The name cannot be empty or start or end with a blank space.", parentValidated.message);
    }

    [Fact]
    public void ParentValidator_Validate_FirstNameStartsWithBlankSpace_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent validParent = Parent.Create(Guid.NewGuid(), " David", "Martinez", "David@gmail.com", "12345678", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(validParent);

        //Assert
        Assert.False(parentValidated.isValid);
        Assert.Equal("The name cannot be empty or start or end with a blank space.", parentValidated.message);
    }

    [Fact]
    public void ParentValidator_Validate_FirstNameEndsWithBlankSpace_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent validParent = Parent.Create(Guid.NewGuid(), "David ", "Martinez", "David@gmail.com", "12345678", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(validParent);

        //Assert
        Assert.False(parentValidated.isValid);
        Assert.Equal("The name cannot be empty or start or end with a blank space.", parentValidated.message);
    }

    [Fact]
    public void ParentValidator_Validate_FirstNameLenghtMoreThenTheMax_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent validParent = Parent.Create(Guid.NewGuid(), new string('a', maxNamesLenght + 1), "Martinez", "David@gmail.com", "12345678", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(validParent);

        //Assert
        Assert.False(parentValidated.isValid);
        Assert.Equal($"The name cannot exceed {maxNamesLenght} characters.", parentValidated.message);
    }

    [Fact]
    public void ParentValidator_Validate_FirstNameWithSpecialCharacters_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent validParent = Parent.Create(Guid.NewGuid(), "D4v1d", "Martinez", "David@gmail.com", "12345678", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(validParent);

        //Assert
        Assert.False(parentValidated.isValid);
        Assert.Equal("The name cannot contain special characters.", parentValidated.message);
    }
}
