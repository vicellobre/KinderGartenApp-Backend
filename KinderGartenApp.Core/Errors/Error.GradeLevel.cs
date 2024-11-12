namespace KinderGartenApp.Core.Errors;

/// <summary>
/// Representa un error con un código y un mensaje descriptivo.
/// </summary>
public readonly partial record struct Error
{
    /// <summary>
    /// Errores relacionados con el nivel educativo.
    /// </summary>
    public static class GradeLevel
    {
        /// <summary>
        /// Indica que el nivel educativo proporcionado es inválido.
        /// </summary>
        public static readonly Error Invalid = new("GradeLevel.Invalid", "The grade level provided is invalid.");
    }
}
