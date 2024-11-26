namespace KinderGartenApp.Core.Errors;

/// <summary>
/// Representa un error con un código y un mensaje descriptivo.
/// </summary>
public readonly partial record struct Error
{
    /// <summary>
    /// Errores específicos relacionados con la entidad niños.
    /// </summary>
    public static class Child
    {
        /// <summary>
        /// Error que se produce cuando no se encuentra un niño.
        /// </summary>
        public static readonly Error NotFound = new("Child.NotFound", "Child not found");
    }
}
