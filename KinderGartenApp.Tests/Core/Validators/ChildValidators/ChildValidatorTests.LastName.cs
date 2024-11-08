using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core;

namespace KinderGartenApp.Tests.Tests
{
    public partial class ChildValidatorTests
    {
        [Fact]
        public void ChildValidator_Validate_FutureBirthDate_ShouldReturnFalseAndErrorMessage()
        {
            //Arrange
            var validChild = Child.Create(Guid.NewGuid(), "Mateo", "Quiceno", DateTime.Now.AddDays(1), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, 123);

            //Act
            var childValidated = ChildValidator.Validate(validChild);

            //Assert
            Assert.False(childValidated.isValid);
            Assert.Equal("La fecha de nacimiento no puede ser mayor a la fecha actual.", childValidated.message);
        }
    }
}
