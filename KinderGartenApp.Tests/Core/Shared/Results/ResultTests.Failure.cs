using KinderGartenApp.Core.Errors;
using KinderGartenApp.Core.Shared;

namespace KinderGartenApp.Tests.Core.Shared.Results;

public partial class ResultTests
{
    [Fact]
    public void Failure_WithError_ShouldBeFailure()
    {
        // Arrange
        var error = Error.FirstName.IsNullOrEmpty;

        // Act
        var result = Result<string>.Failure(error);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Throws<InvalidOperationException>(() => result.Value);
        Assert.NotNull(result.Errors);
        Assert.Contains(error, result.Errors);
        Assert.Equal(error, result.FirstError);
    }

    [Fact]
    public void Failure_WithNoneError_ShouldBeFailureWithNullValueError()
    {
        // Arrange
        var error = Error.None;

        // Act
        var result = Result<string>.Failure(error);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Throws<InvalidOperationException>(() => result.Value);
        Assert.NotNull(result.Errors);
        Assert.Contains(Error.NullValue, result.Errors);
        Assert.Equal(Error.NullValue, result.FirstError);
    }

    [Fact]
    public void Failure_WithErrors_ShouldBeFailure()
    {
        // Arrange
        var errors = new List<Error> { Error.FirstName.IsNullOrEmpty, Error.LastName.InvalidSpecialCharacters };

        // Act
        var result = Result<string>.Failure(errors);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Throws<InvalidOperationException>(() => result.Value);
        Assert.NotNull(result.Errors);
        Assert.Contains(errors[0], result.Errors);
        Assert.Contains(errors[1], result.Errors);
        Assert.Equal(errors, result.Errors);
        Assert.Equal(errors.First(), result.FirstError);
    }

    [Fact]
    public void Failure_WithEmptyErrorsCollection_ShouldBeFailureWithNullValueError()
    {
        // Arrange
        var errors = new List<Error>();

        // Act
        var result = Result<string>.Failure(errors);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Throws<InvalidOperationException>(() => result.Value);
        Assert.NotNull(result.Errors);
        Assert.Contains(Error.NullValue, result.Errors);
        Assert.Equal(Error.NullValue, result.FirstError);
    }

    [Fact]
    public void Failure_WithNullErrorsCollection_ShouldBeFailureWithNullValueError()
    {
        // Arrange
        List<Error>? errors = null;

        // Act
        var result = Result<string>.Failure(errors!);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Throws<InvalidOperationException>(() => result.Value);
        Assert.NotNull(result.Errors);
        Assert.Contains(Error.NullValue, result.Errors);
        Assert.Equal(Error.NullValue, result.FirstError);
    }
}
