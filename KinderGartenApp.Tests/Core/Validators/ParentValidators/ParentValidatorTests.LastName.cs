using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Validators;

namespace KinderGartenApp.Tests.Core.Validators.ParentValidators;

public partial class ParentValidatorTests
{
    [Fact]
    public void ParentValidator_Validate_LastNameEmpty_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent validParent = Parent.Create(Guid.NewGuid(), "David", "", "David@gmail.com", "12345678", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(validParent);

        //Assert
        Assert.False(parentValidated.isValid);
        Assert.Equal("The last name cannot be empty or start or end with a blank space.", parentValidated.message);
    }

    [Fact]
    public void ParentValidator_Validate_LastNameBlankSpaces_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent validParent = Parent.Create(Guid.NewGuid(), "David", "   ", "David@gmail.com", "12345678", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(validParent);

        //Assert
        Assert.False(parentValidated.isValid);
        Assert.Equal("The last name cannot be empty or start or end with a blank space.", parentValidated.message);
    }

    [Fact]
    public void ParentValidator_Validate_LastNameStartsWithBlankSpace_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent validParent = Parent.Create(Guid.NewGuid(), "David", " Martinez", "David@gmail.com", "12345678", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(validParent);

        //Assert
        Assert.False(parentValidated.isValid);
        Assert.Equal("The last name cannot be empty or start or end with a blank space.", parentValidated.message);
    }

    [Fact]
    public void ParentValidator_Validate_LastNameEndsWithBlankSpace_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent validParent = Parent.Create(Guid.NewGuid(), "David", "Martinez ", "David@gmail.com", "12345678", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(validParent);

        //Assert
        Assert.False(parentValidated.isValid);
        Assert.Equal("The last name cannot be empty or start or end with a blank space.", parentValidated.message);
    }

    [Fact]
    public void ParentValidator_Validate_LastNameLenghtMoreThenTheMax_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent validParent = Parent.Create(Guid.NewGuid(), "David", new string('a', maxNamesLenght + 1), "David@gmail.com", "12345678", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(validParent);

        //Assert
        Assert.False(parentValidated.isValid);
        Assert.Equal($"The last name cannot exceed {maxNamesLenght} characters.", parentValidated.message);
    }

    [Fact]
    public void ParentValidator_Validate_LastNameWithSpecialCharacters_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent validParent = Parent.Create(Guid.NewGuid(), "David", "M4rt1nez", "David@gmail.com", "12345678", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(validParent);

        //Assert
        Assert.False(parentValidated.isValid);
        Assert.Equal("The last name cannot contain special characters.", parentValidated.message);
    }
}
