using KinderGartenApp.Core.Errors;
using KinderGartenApp.Core.Extensions;

namespace KinderGartenApp.Tests.Core.Extensions.Results;

public class ResultExtensionsTests
{
    [Fact]
    public void ToResult_FromValue_ShouldReturnSuccessResult()
    {
        // Arrange
        var value = "test";

        // Act
        var result = value.ToResult();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(value, result.Value);
        Assert.Empty(result.Errors);
        Assert.Equal(Error.None, result.FirstError);
    }

    [Fact]
    public void ToResult_FromError_ShouldReturnFailureResult()
    {
        // Arrange
        var error = Error.Create("TestError.Code", "Test error message.");

        // Act
        var result = error.ToResult<string>();

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Throws<InvalidOperationException>(() => result.Value);
        Assert.Contains(error, result.Errors);
        Assert.Equal(error, result.FirstError);
    }

    [Fact]
    public void ToResult_FromErrorsCollection_ShouldReturnFailureResult()
    {
        // Arrange
        ICollection<Error> errors = [Error.Create("Error1.Code", "Error 1 message"), Error.Create("Error2.Code", "Error 2 message")];

        // Act
        var result = errors.ToResult<string>();

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Throws<InvalidOperationException>(() => result.Value);
        Assert.Equal(errors, result.Errors);
        Assert.Equal(errors.First(), result.FirstError);
    }

    [Fact]
    public void ToResult_FromErrorsList_ShouldReturnFailureResult()
    {
        // Arrange
        List<Error> errors = [Error.Create("Error1.Code", "Error 1 message"), Error.Create("Error2.Code", "Error 2 message")];

        // Act
        var result = errors.ToResult<string>();

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Throws<InvalidOperationException>(() => result.Value);
        Assert.Equal(errors, result.Errors);
        Assert.Equal(errors.First(), result.FirstError);
    }

    [Fact]
    public void ToResult_FromErrorsHashSet_ShouldReturnFailureResult()
    {
        // Arrange
        HashSet<Error> errors = [Error.Create("Error1.Code", "Error 1 message"), Error.Create("Error2.Code", "Error 2 message")];

        // Act
        var result = errors.ToResult<string>();

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Throws<InvalidOperationException>(() => result.Value);

        // Ordena los conjuntos de errores antes de compararlos
        Assert.Equal(errors.OrderBy(e => e.Code), result.Errors.OrderBy(e => e.Code));
        Assert.Equal(errors.First(), result.FirstError);
    }

    [Fact]
    public void ToResult_FromErrorsArray_ShouldReturnFailureResult()
    {
        // Arrange
        Error[] errors = [Error.Create("Error1.Code", "Error 1 message"), Error.Create("Error2.Code", "Error 2 message")];

        // Act
        var result = errors.ToResult<string>();

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Throws<InvalidOperationException>(() => result.Value);
        Assert.Equal(errors, result.Errors);
        Assert.Equal(errors.First(), result.FirstError);
    }
}
