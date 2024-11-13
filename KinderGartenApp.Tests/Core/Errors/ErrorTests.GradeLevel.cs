using KinderGartenApp.Core.Errors;

namespace KinderGartenApp.Tests.Core.Errors;

public partial class ErrorTests
{
    [Fact]
    public void GradeLevel_Invalid_ShouldHaveCorrectValues()
    {
        // Arrange
        var expectedCode = "GradeLevel.Invalid";
        var expectedMessage = "The grade level provided is invalid.";

        // Act
        var error = Error.GradeLevel.Invalid;

        // Assert
        Assert.Equal(expectedCode, error.Code);
        Assert.Equal(expectedMessage, error.Message);
    }
}
