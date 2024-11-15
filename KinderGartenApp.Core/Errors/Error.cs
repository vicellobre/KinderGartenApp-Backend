namespace KinderGartenApp.Core.Errors;

/// <summary>
/// Representa un error con un código y un mensaje descriptivo.
/// </summary>
public readonly partial record struct Error
{
    /// <summary>
    /// Representa la ausencia de errores.
    /// </summary>
    public readonly static Error None = new();

    /// <summary>
    /// Representa un error cuando el valor especificado es nulo.
    /// </summary>
    public readonly static Error NullValue = new("Error.NullValue", "The specified result value is null.");

    /// <summary>
    /// Representa un error desconocido.
    /// </summary>
    public readonly static Error Unknown = new("Error.Unknown", "An unknown error occurred.");

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
    /// Inicializa una nueva instancia de la estructura <see cref="Error"/> con valores predeterminados.
    /// </summary>
    public Error()
    {
        Code = string.Empty;
        Message = string.Empty;
    }

    /// <summary>
    /// Inicializa una nueva instancia de la estructura <see cref="Error"/> con el código y mensaje especificados.
    /// </summary>
    /// <param name="code">El código del error.</param>
    /// <param name="message">El mensaje descriptivo del error.</param>
    /// <exception cref="ArgumentNullException">Se produce cuando el código o el mensaje son nulos.</exception>
    private Error(string? code, string? message) : this()
    {
        if (code is null)
        {
            throw new ArgumentNullException(nameof(code), "Error code cannot be null.");
        }

        if (message is null)
        {
            throw new ArgumentNullException(nameof(message), "Error message cannot be null.");
        }

        Code = !string.IsNullOrWhiteSpace(code) ? code : None.Code;
        Message = !string.IsNullOrWhiteSpace(message) ? message : None.Message;
    }

    /// <summary>
    /// Crea una nueva instancia de la estructura <see cref="Error"/> con el código y mensaje especificados.
    /// </summary>
    /// <param name="code">El código del error.</param>
    /// <param name="message">El mensaje descriptivo del error.</param>
    /// <returns>Una nueva instancia de la estructura <see cref="Error"/>.</returns>
    public static Error Create(string? code, string? message) => new(code, message);
}