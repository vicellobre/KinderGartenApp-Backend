using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core;

namespace KinderGartenApp.Tests.Tests
{
    public partial class ChildValidatorTests
    {
        [Fact]
        public void ChildValidator_Validate_LastNameNull_ShouldReturnFalseAndErrorMessage()
        {
            //Arrange
            var validChild = Child.Create(Guid.NewGuid(), "Mateo", "", DateTime.Now.AddYears(-5), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, 123);

            //Act
            var childValidated = ChildValidator.Validate(validChild);

            //Assert
            Assert.False(childValidated.isValid);
            Assert.Equal("El apellido no puede estar vacío o empezar o terminar con un espacio en blanco.", childValidated.message);
        }

        [Fact]
        public void ChildValidator_Validate_LastNameWithWhiteSpace_ShouldReturnFalseAndErrorMessage()
        {
            //Arrange
            var validChild = Child.Create(Guid.NewGuid(), "Mateo", "   ", DateTime.Now.AddYears(-5), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, 123);

            //Act
            var childValidated = ChildValidator.Validate(validChild);

            //Assert
            Assert.False(childValidated.isValid);
            Assert.Equal("El apellido no puede estar vacío o empezar o terminar con un espacio en blanco.", childValidated.message);
        }

        [Fact]
        public void ChildValidator_Validate_LastNameWithFirstSpaceBlank_ShouldReturnFalseAndErrorMessage()
        {
            //Arrange
            var validChild = Child.Create(Guid.NewGuid(), "Mateo", " Quiceno", DateTime.Now.AddYears(-5), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, 123);

            //Act
            var childValidated = ChildValidator.Validate(validChild);

            //Assert
            Assert.False(childValidated.isValid);
            Assert.Equal("El apellido no puede estar vacío o empezar o terminar con un espacio en blanco.", childValidated.message);
        }

        [Fact]
        public void ChildValidator_Validate_LastNameWithLastSpaceBlank_ShouldReturnFalseAndErrorMessage()
        {
            //Arrange
            var validChild = Child.Create(Guid.NewGuid(), "Mateo", "Quiceno ", DateTime.Now.AddYears(-5), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, 123);

            //Act
            var childValidated = ChildValidator.Validate(validChild);

            //Assert
            Assert.False(childValidated.isValid);
            Assert.Equal("El apellido no puede estar vacío o empezar o terminar con un espacio en blanco.", childValidated.message);
        }

        [Fact]
        public void ChildValidator_Validate_LastNameLenghtMoreThenTheMax_ShouldReturnFalseAndErrorMessage()
        {
            //Arrange
            var validChild = Child.Create(Guid.NewGuid(), "Mateo", new string('a', 51), DateTime.Now.AddYears(-5), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, 123);

            //Act
            var childValidated = ChildValidator.Validate(validChild);

            //Assert
            Assert.False(childValidated.isValid);
            Assert.Equal("El apellido no puede tener más de 50 caracteres.", childValidated.message);
        }
    }
}
