using KinderGartenApp.Core.Errors;
using KinderGartenApp.Core.Shared;

namespace KinderGartenApp.Tests.Core.Shared.Results;

public partial class ResultTests
{
    [Fact]
    public void ImplicitConversion_FromValidValue_ShouldBeSuccess()
    {
        // Arrange
        var value = "test";

        // Act
        Result<string> result = value;

        // Assert
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.Equal(value, result.Value);
        Assert.NotNull(result.Errors);
        Assert.Empty(result.Errors);
        Assert.Equal(Error.None, result.FirstError);
    }

    [Fact]
    public void ImplicitConversion_FromNullValue_ShouldBeFailure()
    {
        // Arrange
        string? value = null;

        // Act
        Result<string?> result = value;

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Throws<InvalidOperationException>(() => result.Value);
        Assert.NotNull(result.Errors);
        Assert.Contains(Error.NullValue, result.Errors);
        Assert.Equal(Error.NullValue, result.FirstError);
    }

    [Fact]
    public void ImplicitConversion_FromError_ShouldHandleSpecificError()
    {
        // Arrange
        var error = Error.Create("TestError.Code", "Test error message.");

        // Act
        Result<string> result = error;

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Throws<InvalidOperationException>(() => result.Value);
        Assert.NotNull(result.Errors);
        Assert.Contains(error, result.Errors);
        Assert.Equal(error, result.FirstError);
    }

    [Fact]
    public void ImplicitConversion_FromError_ShouldHandleNoneError()
    {
        // Arrange
        var error = Error.None;

        // Act
        Result<string> result = error;

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Throws<InvalidOperationException>(() => result.Value);
        Assert.NotNull(result.Errors);
        Assert.Contains(Error.NullValue, result.Errors);
        Assert.Equal(Error.NullValue, result.FirstError);
    }

    [Fact]
    public void ImplicitConversion_FromErrorsCollection_ShouldHandleSpecificErrors()
    {
        // Arrange
        var errors = new List<Error> { Error.FirstName.IsNullOrEmpty, Error.LastName.InvalidSpecialCharacters };

        // Act
        Result<string> result = errors;

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Throws<InvalidOperationException>(() => result.Value);
        Assert.NotNull(result.Errors);
        Assert.Equal(errors, result.Errors);
        Assert.Equal(errors.First(), result.FirstError);
    }


    [Fact]
    public void ImplicitConversion_FromErrorsArray_ShouldHandleEmptyErrorsCollection()
    {
        // Arrange
        var errors = new HashSet<Error>();

        // Act
        Result<string> result = errors;

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Throws<InvalidOperationException>(() => result.Value);
        Assert.NotNull(result.Errors);
        Assert.Contains(Error.NullValue, result.Errors);
        Assert.Equal(Error.NullValue, result.FirstError);
    }



    [Fact]
    public void ImplicitConversion_FromErrorsHashSet_ShouldHandleEmptyErrorsCollection()
    {
        // Arrange
        Error[] errors = [];

        // Act
        Result<string> result = errors;

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Throws<InvalidOperationException>(() => result.Value);
        Assert.NotNull(result.Errors);
        Assert.Contains(Error.NullValue, result.Errors);
        Assert.Equal(Error.NullValue, result.FirstError);
    }

    [Fact]
    public void ImplicitConversion_FromErrorsCollection_ShouldHandleNullErrorsCollection()
    {
        // Arrange
        List<Error>? errors = null;

        // Act
        Result<string> result = errors!;

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Throws<InvalidOperationException>(() => result.Value);
        Assert.NotNull(result.Errors);
        Assert.Contains(Error.NullValue, result.Errors);
        Assert.Equal(Error.NullValue, result.FirstError);
    }
}
