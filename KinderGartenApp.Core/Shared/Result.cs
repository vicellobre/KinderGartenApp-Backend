using KinderGartenApp.Core.Errors;

namespace KinderGartenApp.Core.Shared;

/// <summary>
/// Representa el resultado de una operación, que puede ser exitosa o contener uno o más errores.
/// </summary>
public readonly record struct Result
{
    /// <summary>
    /// Obtiene la colección de errores asociados con el resultado.
    /// </summary>
    public ICollection<Error> Errors { get; init; }

    /// <summary>
    /// Indica si el resultado es exitoso.
    /// </summary>
    public bool IsSuccess => Errors is null || Errors.Count <= 0;

    /// <summary>
    /// Obtiene el primer error en la colección de errores.
    /// </summary>
    /// <exception cref="InvalidOperationException">Se lanza cuando no hay errores registrados y se intenta acceder a la propiedad FirstError.</exception>
    public Error FirstError => IsSuccess
        ? throw new InvalidOperationException("The FirstError property cannot be accessed when no errors have been recorded. Check IsError before accessing FirstError.")
        : Errors.First();

    /// <summary>
    /// Inicializa una nueva instancia de la estructura <see cref="Result"/> con un único error especificado.
    /// </summary>
    /// <param name="error">El error asociado con el resultado.</param>
    private Result(Error error) : this()
    {
        Errors = [error];
    }

    /// <summary>
    /// Inicializa una nueva instancia de la estructura <see cref="Result"/> con una colección de errores especificada.
    /// </summary>
    /// <param name="errors">La colección de errores asociados con el resultado.</param>
    private Result(ICollection<Error> errors) : this()
    {
        Errors = errors;
    }

    /// <summary>
    /// Crea una nueva instancia de la estructura <see cref="Result"/> representando un resultado exitoso.
    /// </summary>
    /// <returns>Una nueva instancia de la estructura <see cref="Result"/> sin errores.</returns>
    public static Result Success() => new(Error.None);

    /// <summary>
    /// Crea una nueva instancia de la estructura <see cref="Result"/> representando un resultado fallido con un único error especificado.
    /// </summary>
    /// <param name="error">El error que describe la falla.</param>
    /// <returns>Una nueva instancia de la estructura <see cref="Result"/> con el error especificado.</returns>
    public static Result Failure(Error error) => new(error);

    /// <summary>
    /// Crea una nueva instancia de la estructura <see cref="Result"/> representando un resultado fallido con una colección de errores especificada.
    /// </summary>
    /// <param name="errors">La colección de errores que describen la falla.</param>
    /// <returns>Una nueva instancia de la estructura <see cref="Result"/> con la colección de errores especificada.</returns>
    public static Result Failure(ICollection<Error> errors) => new(errors);
}
