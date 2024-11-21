namespace KinderGartenApp.Core.Errors;

/// <summary>
/// Representa un error con un código y un mensaje descriptivo.
/// </summary>
public readonly partial record struct Error
{
    /// <summary>
    /// Errores relacionados con el phone.
    /// </summary>
    public static class Phone
    {
        /// <summary>
        /// Indica que el phone no puede estar vacío.
        /// </summary>
        public static readonly Error IsNullOrEmpty = new("Phone.IsNullOrEmpty", "The phone cannot be empty.");

        /// <summary>
        /// Indica que el phone debe de seguir el formato establecido.
        /// </summary>
        public static readonly Error InvalidFormat = new("Phone.InvalidFormat", "The phone does not meet the formatting guidelines");
    }
}
