using KinderGartenApp.Core.Errors;

namespace KinderGartenApp.Core.Shared;

/// <summary>
/// Representa el resultado de una operación, que puede ser exitosa o contener un error.
/// </summary>
public readonly record struct Result
{
    /// <summary>
    /// Obtiene el error asociado con el resultado, si lo hay.
    /// </summary>
    public Error Error { get; init; }

    /// <summary>
    /// Indica si el resultado es exitoso.
    /// </summary>
    public bool IsSuccess => Error == Error.None;

    /// <summary>
    /// Inicializa una nueva instancia de la estructura <see cref="Result"/> con el error especificado.
    /// </summary>
    /// <param name="error">El error asociado con el resultado.</param>
    private Result(Error error) : this()
    {
        Error = error;
    }

    /// <summary>
    /// Crea una nueva instancia de la estructura <see cref="Result"/> representando un resultado exitoso.
    /// </summary>
    /// <returns>Una nueva instancia de la estructura <see cref="Result"/> sin errores.</returns>
    public static Result Success() => new(Error.None);

    /// <summary>
    /// Crea una nueva instancia de la estructura <see cref="Result"/> representando un resultado fallido con el error especificado.
    /// </summary>
    /// <param name="error">El error que describe la falla.</param>
    /// <returns>Una nueva instancia de la estructura <see cref="Result"/> con el error especificado.</returns>
    public static Result Failure(Error error) => new(error);
}
