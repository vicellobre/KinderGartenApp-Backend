using KinderGartenApp.Core.Entities;

namespace KinderGartenApp.Core
{
    public static class ChildValidator
    {
        public static void Validate(Child child)
        {

            if (child.FullName == "" || child.FullName.StartsWith(' ') || child.FullName.EndsWith(' '))
                throw new ArgumentException("El nombre no puede estar vacío o empezar o terminar con un espacio en blanco.");

            if (child.FullName.Length > 100)
                throw new ArgumentException("El nombre no puede tener más de 100 caracteres.");

            if (child.BirthDate > DateTime.Now)
                throw new ArgumentException("La fecha de nacimiento no puede ser mayor a la fecha actual.");

            if (child.ParentId <= 0)
                throw new ArgumentException("El ID del padre no puede ser menor o igual a 0.");

        }
    }
}