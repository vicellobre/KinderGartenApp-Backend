using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core;

namespace KinderGartenApp.Tests.Tests
{
    public partial class ChildValidatorTests
    {
        [Fact]
        public void ChildValidator_Validate_FirstNameNull_ShouldReturnFalseAndErrorMessage()
        {
            //Arrange
            var validChild = Child.Create(Guid.NewGuid(), "", "Quiceno", DateTime.Now.AddYears(-5), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, 123);

            //Act
            var childValidated = ChildValidator.Validate(validChild);

            //Assert
            Assert.False(childValidated.isValid);
            Assert.Equal("El nombre no puede estar vacío o empezar o terminar con un espacio en blanco.", childValidated.message);
        }

        [Fact]
        public void ChildValidator_Validate_FirstNameWithWhiteSpace_ShouldReturnFalseAndErrorMessage()
        {
            //Arrange
            var validChild = Child.Create(Guid.NewGuid(), "   ", "Quiceno", DateTime.Now.AddYears(-5), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, 123);

            //Act
            var childValidated = ChildValidator.Validate(validChild);

            //Assert
            Assert.False(childValidated.isValid);
            Assert.Equal("El nombre no puede estar vacío o empezar o terminar con un espacio en blanco.", childValidated.message);
        }

        [Fact]
        public void ChildValidator_Validate_FirstNameWithFirstSpaceBlank_ShouldReturnFalseAndErrorMessage()
        {
            //Arrange
            var validChild = Child.Create(Guid.NewGuid(), " Mateo", "Quiceno", DateTime.Now.AddYears(-5), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, 123);

            //Act
            var childValidated = ChildValidator.Validate(validChild);

            //Assert
            Assert.False(childValidated.isValid);
            Assert.Equal("El nombre no puede estar vacío o empezar o terminar con un espacio en blanco.", childValidated.message);
        }

        [Fact]
        public void ChildValidator_Validate_FirstNameWithLastSpaceBlank_ShouldReturnFalseAndErrorMessage()
        {
            //Arrange
            var validChild = Child.Create(Guid.NewGuid(), "Mateo ", "Quiceno", DateTime.Now.AddYears(-5), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, 123);

            //Act
            var childValidated = ChildValidator.Validate(validChild);

            //Assert
            Assert.False(childValidated.isValid);
            Assert.Equal("El nombre no puede estar vacío o empezar o terminar con un espacio en blanco.", childValidated.message);
        }

        [Fact]
        public void ChildValidator_Validate_FirstNameLenghtMoreThenTheMax_ShouldReturnFalseAndErrorMessage()
        {
            //Arrange
            var validChild = Child.Create(Guid.NewGuid(), new string('a', 51), "Quiceno", DateTime.Now.AddYears(-5), KinderGartenApp.Core.Enumarations.GradeLevel.PreKinder, 123);

            //Act
            var childValidated = ChildValidator.Validate(validChild);

            //Assert
            Assert.False(childValidated.isValid);
            Assert.Equal("El nombre no puede tener más de 50 caracteres.", childValidated.message);
        }
    }
}
