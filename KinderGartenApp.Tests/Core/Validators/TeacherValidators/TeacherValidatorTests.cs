using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Validators;

namespace KinderGartenApp.Tests.Core.Validators.TeacherValidators;

public partial class TeacherValidatorTests
{
    [Fact]
    public void Validate_ValidTeacher_ReturnsTrue()
    {
        // Arrange
        var teacher = Teacher.Create(Guid.NewGuid(), "Juan", "Pérez", GradeLevel.PreKinder);

        // Act
        var result = TeacherValidator.Validate(teacher);

        // Assert
        Assert.True(result);
    }
}