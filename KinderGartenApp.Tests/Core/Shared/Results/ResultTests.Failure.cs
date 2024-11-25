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

    [Fact]
    public void Failure_ShouldCreateFailureResult_WithException()
    {
        // Arrange
        var exception = new InvalidOperationException("Invalid operation occurred");

        // Act
        var result = Result<string>.Failure(exception);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Single(result.Errors);
        var error = result.FirstError;
        Assert.Equal("InvalidOperationException", error.Code);
        Assert.Equal("Invalid operation occurred", error.Message);
    }

    [Fact]
    public void Failure_ShouldCreateFailureResult_WithExceptionType()
    {
        // Arrange
        var exception = new ArgumentNullException("paramName", "Parameter cannot be null");

        // Act
        var result = Result<string>.Failure(exception);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Single(result.Errors);
        var error = result.FirstError;
        Assert.Equal("ArgumentNullException", error.Code);
        Assert.Equal("Parameter cannot be null (Parameter 'paramName')", error.Message);
    }

    [Fact]
    public void Failure_ShouldCreateFailureResult_WithNullException()
    {
        // Arrange
        Exception? exception = null;

        // Act & Assert
        Assert.Throws<NullReferenceException>(() => Result<string>.Failure(exception!));
    }
}
