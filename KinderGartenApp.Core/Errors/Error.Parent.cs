namespace KinderGartenApp.Core.Errors;

/// <summary>
/// Representa un error con un código y un mensaje descriptivo.
/// </summary>
public readonly partial record struct Error
{
    /// <summary>
    /// Errores específicos relacionados con la entidad niños.
    /// </summary>
    public static class Parent
    {
        /// <summary>
        /// Error que se produce cuando no se encuentra un niño.
        /// </summary>
        public static readonly Error NotFound = new("Parent.NotFound", "Parent not found");

        /// <summary>
        /// Error que se produce cuando un niño es nulo.
        /// </summary>
        public static readonly Error IsNull = new("Parent.IsNull", "Parent cannot be null");
    }
}
