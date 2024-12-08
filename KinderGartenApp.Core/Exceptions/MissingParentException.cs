namespace KinderGartenApp.Core.Exceptions;

/// <summary>
/// Excepción que se lanza cuando el objeto Parent no ha sido seteado antes de realizar una operación.
/// </summary>
public class MissingParentException : Exception
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="MissingParentException"/> con un mensaje predeterminado.
    /// </summary>
    public MissingParentException()
        : base("Parent must be set before performing this operation.")
    {
    }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="MissingParentException"/> con un mensaje de error especificado.
    /// </summary>
    /// <param name="message">El mensaje que describe el error.</param>
    public MissingParentException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="MissingParentException"/> con un mensaje de error especificado
    /// y una referencia a la excepción interna que es la causa de esta excepción.
    /// </summary>
    /// <param name="message">El mensaje que describe el error.</param>
    /// <param name="innerException">La excepción que es la causa de la excepción actual.</param>
    public MissingParentException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
