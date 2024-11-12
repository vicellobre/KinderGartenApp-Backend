namespace KinderGartenApp.Core.Shared;

/// <summary>
/// Representa el resultado de una operación que puede ser exitosa o contener un error, 
/// con un valor resultante.
/// </summary>
/// <typeparam name="TValue">El tipo del valor resultante.</typeparam>
public readonly record struct Result<TValue>
{
    // Fields
    /// <summary>
    /// El valor resultante de la operación.
    /// </summary>
    private readonly TValue? _value;

    /// <summary>
    /// El resultado de la operación sin el valor.
    /// </summary>
    private readonly Result _result;

    // Properties
    /// <summary>
    /// Obtiene el valor resultante de la operación si es exitosa; de lo contrario, lanza una excepción.
    /// </summary>
    public TValue Value => IsSuccess ? _value! : throw new InvalidOperationException("The value of a failure result cannot be accessed.");

    /// <summary>
    /// Indica si el resultado es exitoso.
    /// </summary>
    public bool IsSuccess => _result.IsSuccess;

    /// <summary>
    /// Obtiene el error asociado con el resultado, si lo hay.
    /// </summary>
    public Error Error => _result.Error;

    // Constructor
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

    // Factory
    /// <summary>
    /// Crea una nueva instancia de la estructura <see cref="Result{TValue}"/> representando un resultado exitoso con el valor especificado.
    /// </summary>
    /// <param name="value">El valor resultante de la operación.</param>
    /// <returns>Una nueva instancia de la estructura <see cref="Result{TValue}"/> sin errores.</returns>
    public static Result<TValue> Success(TValue value) => new(value, Error.None);

    /// <summary>
    /// Crea una nueva instancia de la estructura <see cref="Result{TValue}"/> representando un resultado fallido con el error especificado.
    /// </summary>
    /// <param name="error">El error que describe la falla.</param>
    /// <returns>Una nueva instancia de la estructura <see cref="Result{TValue}"/> con el error especificado.</returns>
    public static Result<TValue> Failure(Error error) => new(default, error);

    /// <summary>
    /// Crea una nueva instancia de la estructura <see cref="Result{TValue}"/> con el valor especificado, 
    /// o un resultado fallido si el valor es nulo.
    /// </summary>
    /// <param name="value">El valor resultante de la operación.</param>
    /// <returns>Una nueva instancia de la estructura <see cref="Result{TValue}"/>.</returns>
    public static Result<TValue> Create(TValue? value) => value is not null ? Success(value) : Failure(Error.NullValue);
}
