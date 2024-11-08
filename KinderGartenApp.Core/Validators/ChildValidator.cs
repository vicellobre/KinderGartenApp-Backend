using KinderGartenApp.Core.Entities;

namespace KinderGartenApp.Core
{
    public static class ChildValidator
    {
        private const int maxNamesLenght = 50;

        public static (bool isValid, string? message) Validate(Child child)
        {

            if (string.IsNullOrWhiteSpace(child.FirstName) || child.FirstName.StartsWith(' ') || child.FirstName.EndsWith(' '))
                return (false, "El nombre no puede estar vacío o empezar o terminar con un espacio en blanco.");

            if (child.FirstName.Length > 100)
                return (false, $"El nombre no puede tener más de {maxNamesLenght} caracteres.");

            if (string.IsNullOrWhiteSpace(child.LastName) || child.LastName.StartsWith(' ') || child.LastName.EndsWith(' '))
                return (false, "El apellido no puede estar vacío o empezar o terminar con un espacio en blanco.");

            if (child.LastName.Length > 100)
                return (false, $"El apellido no puede tener más de {maxNamesLenght} caracteres.");

            if (child.BirthDate > DateTime.Now)
                return (false, "La fecha de nacimiento no puede ser mayor a la fecha actual.");

            if (child.ParentId <= 0)
                return (false, "El ID del padre no puede ser menor o igual a 0.");

            return (true, string.Empty);
        }
    }
}