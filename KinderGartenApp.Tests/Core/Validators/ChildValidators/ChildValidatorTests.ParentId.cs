using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core;

namespace KinderGartenApp.Tests.Tests
{
    public partial class ChildValidatorTests
    {
        [Fact]
        public void ChildValidator_Validate_ParentIdZero_ShouldReturnFalseAndErrorMessage()
        {
            //Arrange
            var validChild = Child.Create(Guid.NewGuid(), "Mateo", "Quiceno", DateTime.Now.AddYears(-5), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, 0);

            //Act
            var childValidated = ChildValidator.Validate(validChild);

            //Assert
            Assert.False(childValidated.isValid);
            Assert.Equal("El ID del padre no puede ser menor o igual a 0.", childValidated.message);
        }

        [Fact]
        public void ChildValidator_Validate_ParentIdUnderZero_ShouldReturnFalseAndErrorMessage()
        {
            //Arrange
            var validChild = Child.Create(Guid.NewGuid(), "Mateo", "Quiceno", DateTime.Now.AddYears(-5), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, -1);

            //Act
            var childValidated = ChildValidator.Validate(validChild);

            //Assert
            Assert.False(childValidated.isValid);
            Assert.Equal("El ID del padre no puede ser menor o igual a 0.", childValidated.message);
        }
    }
}
