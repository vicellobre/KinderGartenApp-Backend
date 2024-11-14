using KinderGartenApp.Core.Errors;
using KinderGartenApp.Core.Shared;

namespace KinderGartenApp.Tests.Core.Shared.Results;

public partial class ResultTests
{
    [Fact]
    public void Create_WithValidValue_ShouldBeSuccess()
    {
        // Arrange
        var value = "test";

        // Act
        var result = Result<string>.Create(value);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.Equal(value, result.Value);
        Assert.NotNull(result.Errors);
        Assert.Empty(result.Errors);
        Assert.Equal(Error.None, result.FirstError);
    }

    [Fact]
    public void Create_WithNullValue_ShouldBeFailure()
    {
        // Arrange
        string? value = null;

        // Act
        var result = Result<string>.Create(value);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Throws<InvalidOperationException>(() => result.Value);
        Assert.NotNull(result.Errors);
        Assert.Contains(Error.NullValue, result.Errors);
        Assert.Equal(Error.NullValue, result.FirstError);
    }
}
