namespace KinderGartenApp.Core.Exceptions;

/// <summary>
/// Excepción que se lanza cuando el objeto Teacher no ha sido seteado antes de realizar una operación.
/// </summary>
public class MissingTeacherException : Exception
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="MissingTeacherException"/> con un mensaje predeterminado.
    /// </summary>
    public MissingTeacherException()
        : base("Teacher must be set before performing this operation.")
    {
    }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="MissingTeacherException"/> con un mensaje de error especificado.
    /// </summary>
    /// <param name="message">El mensaje que describe el error.</param>
    public MissingTeacherException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="MissingTeacherException"/> con un mensaje de error especificado
    /// y una referencia a la excepción interna que es la causa de esta excepción.
    /// </summary>
    /// <param name="message">El mensaje que describe el error.</param>
    /// <param name="innerException">La excepción que es la causa de la excepción actual.</param>
    public MissingTeacherException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
