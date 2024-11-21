namespace KinderGartenApp.Core.Errors;

/// <summary>
/// Representa un error con un código y un mensaje descriptivo.
/// </summary>
public readonly partial record struct Error
{
    /// <summary>
    /// Errores relacionados con el password.
    /// </summary>
    public static class Password
    {
        /// <summary>
        /// Indica que el password no puede estar vacío.
        /// </summary>
        public static readonly Error IsNullOrEmpty = new("Password.IsNullOrEmpty", "The password cannot be empty.");

        /// <summary>
        /// Indica que el password no puede exceder la longitud especificada.
        /// </summary>
        /// <param name="length">La longitud máxima permitida para el password.</param>
        /// <returns>Una nueva instancia de <see cref="Error"/> con un mensaje que indica que el password es demasiado largo.</returns>
        public static readonly Func<int, Error> TooLong = length => new Error("Password.TooLong", $"The password cannot exceed {length} characters.");

        /// <summary>
        /// Indica que el password no puede estar por debajo de la longitud establecida.
        /// </summary>
        /// <param name="length">La longitud minima permitida para el password.</param>
        /// <returns>Una nueva instancia de <see cref="Error"/> con un mensaje que indica que el password es demasiado corto.</returns>
        public static readonly Func<int, Error> TooShort = length => new Error("Password.TooShort", $"The password must be at least {length} characters.");
    }
}
