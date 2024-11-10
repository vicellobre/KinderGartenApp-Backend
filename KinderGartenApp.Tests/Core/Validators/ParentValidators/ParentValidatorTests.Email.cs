using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Validators;

namespace KinderGartenApp.Tests.Core.Validators.ParentValidators;

public partial class ParentValidatorTests
{
    [Fact]
    public void ParentValidator_Validate_EmailEmpty_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "", "12345678", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(parent);

        //Assert
        Assert.False(parentValidated.isValid);
        Assert.Equal("The email cannot be empty or contain a blank space.", parentValidated.message);
    }

    [Fact]
    public void ParentValidator_Validate_EmailBlankSpaces_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "   ", "12345678", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(parent);

        //Assert
        Assert.False(parentValidated.isValid);
        Assert.Equal("The email cannot be empty or contain a blank space.", parentValidated.message);
    }

    [Fact]
    public void ParentValidator_Validate_EmailMidBlankSpace_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David @gmail.com", "12345678", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(parent);

        //Assert
        Assert.False(parentValidated.isValid);
        Assert.Equal("The email cannot be empty or contain a blank space.", parentValidated.message);
    }

    [Fact]
    public void ParentValidator_Validate_EmailLenghtMoreThenTheMax_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", new string('a', maxEmailLenght + 1), "12345678", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(parent);

        //Assert
        Assert.False(parentValidated.isValid);
        Assert.Equal($"The email lenght cannot exceed {maxEmailLenght} characters.", parentValidated.message);
    }

    [Fact]
    public void ParentValidator_Validate_EmailLenghtLessThenTheMin_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", new string('a', minEmailLenght - 1), "12345678", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(parent);

        //Assert
        Assert.False(parentValidated.isValid);
        Assert.Equal($"The email lenght cannot be under {minEmailLenght} characters.", parentValidated.message);
    }

    [Fact]
    public void ParentValidator_Validate_EmailWithAWrongFormat_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent parent1 = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.c", "12345678", "1234567890");
        Parent parent2 = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@.com", "12345678", "1234567890");
        Parent parent3 = Parent.Create(Guid.NewGuid(), "David", "Martinez", "@gmail.com", "12345678", "1234567890");

        //Act
        var parentValidated1 = ParentValidator.Validate(parent1);
        var parentValidated2 = ParentValidator.Validate(parent2);
        var parentValidated3 = ParentValidator.Validate(parent3);

        //Assert
        Assert.False(parentValidated1.isValid);
        Assert.False(parentValidated2.isValid);
        Assert.False(parentValidated3.isValid);
        Assert.Equal("Invalid email format.", parentValidated1.message);
        Assert.Equal("Invalid email format.", parentValidated2.message);
        Assert.Equal("Invalid email format.", parentValidated3.message);
    }
}
