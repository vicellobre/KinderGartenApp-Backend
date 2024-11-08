using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core;

namespace KinderGartenApp.Tests.Tests
{
    public partial class ChildValidatorTests
    {
        [Fact]
        public void ChildValidator_Validate_IdealScenario_ShouldReturnTrue()
        {
            //Arrange
            var validChild = Child.Create(Guid.NewGuid(), "Mateo", "Quiceno", DateTime.Now.AddYears(-5), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, 123);

            //Act
            var childValidated = ChildValidator.Validate(validChild);

            //Assert
            Assert.True(childValidated.isValid);
        }
    }
}
