using KinderGartenApp.Core.Errors;
using KinderGartenApp.Core.Shared;

namespace KinderGartenApp.Tests.Core.Shared.Results;

public partial class ResultTests
{
    [Fact]
    public void Success_WithValidValue_ShouldBeSuccess()
    {
        // Arrange
        var value = "test";

        // Act
        var result = Result<string>.Success(value);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.Equal(value, result.Value);
        Assert.NotNull(result.Errors);
        Assert.Empty(result.Errors);
        Assert.Equal(Error.None, result.FirstError);
    }
}
