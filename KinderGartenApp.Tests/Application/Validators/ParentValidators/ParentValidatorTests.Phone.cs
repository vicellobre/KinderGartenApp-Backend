using KinderGartenApp.Application.Validators;
using KinderGartenApp.Core.Entities;

namespace KinderGartenApp.Tests.Application.Validators.ParentValidators;

public partial class ParentValidatorTests
{
    [Fact]
    public void ParentValidator_Validate_PhoneEmpty_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "12345678", "");

        //Act
        var parentValidated = ParentValidator.Validate(parent);

        //Assert
        Assert.False(parentValidated.IsSuccess);
    }

    [Fact]
    public void ParentValidator_Validate_PhoneBlankSpaces_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "12345678", "   ");

        //Act
        var parentValidated = ParentValidator.Validate(parent);

        //Assert
        Assert.False(parentValidated.IsSuccess);
    }

    [Fact]
    public void ParentValidator_Validate_PhoneMidBlankSpace_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent parent = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "12345678", "12345 67890");

        //Act
        var parentValidated = ParentValidator.Validate(parent);

        //Assert
        Assert.False(parentValidated.IsSuccess);
    }

    [Fact]
    public void ParentValidator_Validate_PhoneWithAWrongFormat_ShouldReturnFalseAndErrorMessage()
    {
        //Arrange
        Parent phoneLenghtOverTheMax = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "12345678", "12345678901");
        Parent phoneLenghtLessThenTheMin = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "12345678", "123456789");
        Parent phoneWithLetters = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "12345678", "1234lolcow56789");
        Parent phoneWithSpecialCharacters = Parent.Create(Guid.NewGuid(), "David", "Martinez", "David@gmail.com", "12345678", "1234*+ª56789");

        //Act
        var parentValidated1 = ParentValidator.Validate(phoneLenghtOverTheMax);
        var parentValidated2 = ParentValidator.Validate(phoneLenghtLessThenTheMin);
        var parentValidated3 = ParentValidator.Validate(phoneWithLetters);
        var parentValidated4 = ParentValidator.Validate(phoneWithSpecialCharacters);

        //Assert
        Assert.False(parentValidated1.IsSuccess);
        Assert.False(parentValidated2.IsSuccess);
        Assert.False(parentValidated3.IsSuccess);
        Assert.False(parentValidated4.IsSuccess);
    }
}
