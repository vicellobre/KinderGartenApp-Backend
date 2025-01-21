namespace KinderGartenApp.Core.Errors;

/// <summary>
/// Representa un error con un código y un mensaje descriptivo.
/// </summary>
public readonly partial record struct Error
{
    /// <summary>
    /// Errores específicos relacionados con la entidad niños.
    /// </summary>
    public static class Children
    {
        /// <summary>
        /// Error que se produce cuando no se encuentra un niño.
        /// </summary>
        public static readonly Error NotFound = new("Child.NotFound", "Child not found");

        /// <summary>
        /// Error que se produce cuando un niño es nulo.
        /// </summary>
        public static readonly Error IsNull = new("Child.IsNull", "Child cannot be null");
    }

    /// <summary>
    /// Errores específicos relacionados con las solicitudes de Child.
    /// </summary>
    public static class ChildRequest
    {
        /// <summary>
        /// Error que se produce cuando la solicitud de registro del niño es nula.
        /// </summary>
        public static readonly Error RegisterIsNull = new("ChildRequest.RegisterIsNull", "RegisterChild request cannot be null");

        /// <summary>
        /// Error que se produce cuando la solicitud de actualización del niño es nula.
        /// </summary>
        public static readonly Error UpdateIsNull = new("ChildRequest.UpdateIsNull", "UpdateChild request cannot be null");
    }
}
