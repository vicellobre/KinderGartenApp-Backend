namespace KinderGartenApp.Core.Errors;

/// <summary>
/// Representa un error con un código y un mensaje descriptivo.
/// </summary>
public readonly partial record struct Error
{
    /// <summary>
    /// Errores relacionados con el apellido.
    /// </summary>
    public static class LastName
    {
        /// <summary>
        /// Indica que el apellido no puede estar vacío.
        /// </summary>
        public static readonly Error IsNullOrEmpty = new("LastName.IsNullOrEmpty", "The last name cannot be empty.");

        /// <summary>
        /// Indica que el apellido solo puede contener caracteres alfabéticos.
        /// </summary>
        public static readonly Error InvalidSpecialCharacters = new("LastName.InvalidSpecialCharacters", "The last name can only contain alphabetic characters.");

        /// <summary>
        /// Indica que el apellido no puede exceder la longitud especificada.
        /// </summary>
        /// <param name="length">La longitud máxima permitida para el apellido.</param>
        /// <returns>Una nueva instancia de <see cref="Error"/> con un mensaje que indica que el apellido es demasiado largo.</returns>
        public static readonly Func<int, Error> TooLong = length => new Error("LastName.TooLong", $"The last name cannot exceed {length} characters.");
    }
}
