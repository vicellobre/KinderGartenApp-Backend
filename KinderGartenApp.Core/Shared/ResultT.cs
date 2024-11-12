using KinderGartenApp.Core.Errors;

namespace KinderGartenApp.Core.Shared;

/// <summary>
/// Representa el resultado de una operación que puede ser exitosa o contener uno o más errores,
/// con un valor resultante.
/// </summary>
/// <typeparam name="TValue">El tipo del valor resultante.</typeparam>
public readonly record struct Result<TValue>
{
    /// <summary>
    /// El valor resultante de la operación.
    /// </summary>
    private readonly TValue? _value;
    /// <summary>
    /// El resultado de la operación sin el valor.
    /// </summary>
    private readonly Result _result;

    /// <summary>
    /// Obtiene el valor resultante de la operación si es exitosa; de lo contrario, lanza una excepción.
    /// </summary>
    /// <exception cref="InvalidOperationException">Se lanza cuando se intenta acceder al valor de un resultado fallido.</exception>
    public TValue Value => IsSuccess ? _value! : throw new InvalidOperationException("The value of a failure result cannot be accessed.");

    /// <summary>
    /// Indica si el resultado es exitoso.
    /// </summary>
    public bool IsSuccess => _result.IsSuccess;

    /// <summary>
    /// Obtiene la colección de errores asociados con el resultado, si los hay.
    /// </summary>
    public ICollection<Error> Errors => _result.Errors;

    /// <summary>
    /// Obtiene el primer error en la colección de errores.
    /// </summary>
    public Error FirstError => _result.FirstError;

    /// <summary>
    /// Inicializa una nueva instancia de la estructura <see cref="Result{TValue}"/> con el valor y error especificados.
    /// </summary>
    /// <param name="value">El valor resultante de la operación.</param>
    /// <param name="error">El error asociado con el resultado.</param>
    private Result(TValue? value, Error error) : this()
    {
        _result = error == Error.None ? Result.Success() : Result.Failure(error);
        _value = value;
    }

    /// <summary>
    /// Inicializa una nueva instancia de la estructura <see cref="Result{TValue}"/> con el valor y una colección de errores especificada.
    /// </summary>
    /// <param name="value">El valor resultante de la operación.</param>
    /// <param name="errors">La colección de errores asociados con el resultado.</param>
    private Result(TValue? value, ICollection<Error> errors) : this()
    {
        _result = errors is null || errors.Count <= 0 ? Result.Success() : Result.Failure(errors);
        _value = value;
    }

    /// <summary>
    /// Crea una nueva instancia de la estructura <see cref="Result{TValue}"/> representando un resultado exitoso con el valor especificado.
    /// </summary>
    /// <param name="value">El valor resultante de la operación.</param>
    /// <returns>Una nueva instancia de la estructura <see cref="Result{TValue}"/> sin errores.</returns>
    public static Result<TValue> Success(TValue value) => new(value, Error.None);

    /// <summary>
    /// Crea una nueva instancia de la estructura <see cref="Result{TValue}"/> representando un resultado fallido con un único error especificado.
    /// </summary>
    /// <param name="error">El error que describe la falla.</param>
    /// <returns>Una nueva instancia de la estructura <see cref="Result{TValue}"/> con el error especificado.</returns>
    public static Result<TValue> Failure(Error error) => new(default, error);

    /// <summary>
    /// Crea una nueva instancia de la estructura <see cref="Result{TValue}"/> representando un resultado fallido con una colección de errores especificada.
    /// </summary>
    /// <param name="errors">La colección de errores que describen la falla.</param>
    /// <returns>Una nueva instancia de la estructura <see cref="Result{TValue}"/> con la colección de errores especificada.</returns>
    public static Result<TValue> Failure(ICollection<Error> errors) => new(default, errors);

    /// <summary>
    /// Crea una nueva instancia de la estructura <see cref="Result{TValue}"/> con el valor especificado, 
    /// o un resultado fallido si el valor es nulo.
    /// </summary>
    /// <param name="value">El valor resultante de la operación.</param>
    /// <returns>Una nueva instancia de la estructura <see cref="Result{TValue}"/>.</returns>
    public static Result<TValue> Create(TValue? value) => value is not null ? Success(value) : Failure(Error.NullValue);
}
