using KinderGartenApp.Application.Validators;
using KinderGartenApp.Core.Entities;

namespace KinderGartenApp.Tests.Application.Validators.ParentValidators;

public partial class ParentValidatorTests
{
    [Fact]
    public void ParentValidator_Validate_EmailEmpty_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "", "12345678mM*", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(parent);

        //Assert
        Assert.False(parentValidated.IsSuccess);
    }

    [Fact]
    public void ParentValidator_Validate_EmailBlankSpaces_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "   ", "12345678mM*", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(parent);

        //Assert
        Assert.False(parentValidated.IsSuccess);
    }

    [Fact]
    public void ParentValidator_Validate_EmailMidBlankSpace_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David @gmail.com", "12345678mM*", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(parent);

        //Assert
        Assert.False(parentValidated.IsSuccess);
    }

    [Fact]
    public void ParentValidator_Validate_EmailLenghtMoreThenTheMax_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", new string('a', maxEmailLenght + 1), "12345678mM*", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(parent);

        //Assert
        Assert.False(parentValidated.IsSuccess);
    }

    [Fact]
    public void ParentValidator_Validate_EmailLenghtLessThenTheMin_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", new string('a', minEmailLenght - 1), "12345678mM*", "1234567890");

        //Act
        var parentValidated = ParentValidator.Validate(parent);

        //Assert
        Assert.False(parentValidated.IsSuccess);
    }

    [Fact]
    public void ParentValidator_Validate_EmailWithAWrongFormat_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent parent1 = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.c", "12345678mM*", "1234567890");
        Parent parent2 = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@.com", "12345678mM*", "1234567890");
        Parent parent3 = Parent.Create(Guid.NewGuid(), "David", "Martinez", "@gmail.com", "12345678mM*", "1234567890");

        //Act
        var parentValidated1 = ParentValidator.Validate(parent1);
        var parentValidated2 = ParentValidator.Validate(parent2);
        var parentValidated3 = ParentValidator.Validate(parent3);

        //Assert
        Assert.False(parentValidated1.IsSuccess);
        Assert.False(parentValidated2.IsSuccess);
        Assert.False(parentValidated3.IsSuccess);
    }
}
