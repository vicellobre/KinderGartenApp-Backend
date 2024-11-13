namespace KinderGartenApp.Core.Errors;

/// <summary>
/// Representa un error con un código y un mensaje descriptivo.
/// </summary>
public readonly partial record struct Error
{
    /// <summary>
    /// Errores relacionados con el primer nombre.
    /// </summary>
    public static class FirstName
    {
        /// <summary>
        /// Indica que el primer nombre no puede estar vacío.
        /// </summary>
        public static readonly Error IsNullOrEmpty = new("FirstName.IsNullOrEmpty", "The first name cannot be empty.");

        /// <summary>
        /// Indica que el primer nombre solo puede contener caracteres alfabéticos.
        /// </summary>
        public static readonly Error InvalidSpecialCharacters = new("FirstName.InvalidSpecialCharacters", "The first name can only contain alphabetic characters.");

        /// <summary>
        /// Indica que el primer nombre no puede exceder la longitud especificada.
        /// </summary>
        /// <param name="length">La longitud máxima permitida para el primer nombre.</param>
        /// <returns>Una nueva instancia de <see cref="Error"/> con un mensaje que indica que el primer nombre es demasiado largo.</returns>
        public static readonly Func<int, Error> TooLong = length => new Error("FirstName.TooLong", $"The first name cannot exceed {length} characters.");
    }
}
