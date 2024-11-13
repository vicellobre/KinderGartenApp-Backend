using System.Diagnostics.CodeAnalysis;

namespace KinderGartenApp.Core.Errors;

/// <summary>
/// Representa un error con un código y un mensaje descriptivo.
/// </summary>
[ExcludeFromCodeCoverage]
public readonly partial record struct Error
{
    /// <summary>
    /// Representa la ausencia de errores.
    /// </summary>
    public readonly static Error None = new(string.Empty, string.Empty);

    /// <summary>
    /// Representa un error cuando el valor especificado es nulo.
    /// </summary>
    public readonly static Error NullValue = new("Error.NullValue", "The specified result value is null.");

    /// <summary>
    /// Representa una colección de errores vacía.
    /// </summary>
    public static ICollection<Error> EmptyErrors { get; } = [];

    /// <summary>
    /// Código del error.
    /// </summary>
    public string Code { get; init; }

    /// <summary>
    /// Mensaje descriptivo del error.
    /// </summary>
    public string Message { get; init; }

    /// <summary>
    /// Inicializa una nueva instancia de la estructura <see cref="Error"/> con el código y mensaje especificados.
    /// </summary>
    /// <param name="code">El código del error.</param>
    /// <param name="message">El mensaje descriptivo del error.</param>
    private Error(string code, string message) : this()
    {
        Code = code;
        Message = message;
    }

    /// <summary>
    /// Crea una nueva instancia de la estructura <see cref="Error"/> con el código y mensaje especificados.
    /// </summary>
    /// <param name="code">El código del error.</param>
    /// <param name="message">El mensaje descriptivo del error.</param>
    /// <returns>Una nueva instancia de la estructura <see cref="Error"/>.</returns>
    public static Error Create(string code, string message) => new(code, message);
}
