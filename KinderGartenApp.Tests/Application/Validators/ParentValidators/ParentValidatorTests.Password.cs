using KinderGartenApp.Application.Validators;
using KinderGartenApp.Core.Entities;

namespace KinderGartenApp.Tests.Application.Validators.ParentValidators;

public partial class ParentValidatorTests
{
    [Fact]
    public void ParentValidator_Validate_PasswordEmpty_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(parent);

        //Assert
        Assert.False(parentValidated.isValid);
        Assert.Equal("The password cannot be empty or contain a blank space.", parentValidated.message);
    }

    [Fact]
    public void ParentValidator_Validate_PasswordBlankSpaces_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "   ", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(parent);

        //Assert
        Assert.False(parentValidated.isValid);
        Assert.Equal("The password cannot be empty or contain a blank space.", parentValidated.message);
    }

    [Fact]
    public void ParentValidator_Validate_PasswordMidBlankSpace_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "12 345678", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(parent);

        //Assert
        Assert.False(parentValidated.isValid);
        Assert.Equal("The password cannot be empty or contain a blank space.", parentValidated.message);
    }

    [Fact]
    public void ParentValidator_Validate_PasswordLenghtMoreThenTheMax_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", new string('a', maxPasswordLenght + 1), "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(parent);

        //Assert
        Assert.False(parentValidated.isValid);
        Assert.Equal($"The password lenght cannot exceed {maxPasswordLenght} characters.", parentValidated.message);
    }

    [Fact]
    public void ParentValidator_Validate_PasswordLenghtLessThenTheMin_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", new string('a', minPasswordLenght - 1), "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(parent);

        //Assert
        Assert.False(parentValidated.isValid);
        Assert.Equal($"The password lenght cannot be under {minPasswordLenght} characters.", parentValidated.message);
    }
}
