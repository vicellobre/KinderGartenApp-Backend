using KinderGartenApp.Core.Errors;
using KinderGartenApp.Core.Extensions;

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
    /// Obtiene la colección de errores asociados con el resultado, si los hay.
    /// </summary>
    public ICollection<Error> Errors { get; init; }

    /// <summary>
    /// Obtiene el valor resultante de la operación si es exitosa; de lo contrario, lanza una excepción.
    /// </summary>
    /// <exception cref="InvalidOperationException">Se lanza cuando se intenta acceder al valor de un resultado fallido.</exception>
    public TValue? Value => IsSuccess ? _value : throw new InvalidOperationException("The value of a failure result cannot be accessed.");

    /// <summary>
    /// Indica si el resultado es exitoso.
    /// </summary>
    public bool IsSuccess => Errors.IsEmpty();

    /// <summary>
    /// Obtiene el primer error en la colección de errores.
    /// </summary>
    public Error FirstError => Errors.IsEmpty() ? Error.None : Errors.First();

    /// <summary>
    /// Inicializa una nueva instancia de la estructura <see cref="Result{TValue}"/> con el valor especificado.
    /// </summary>
    /// <param name="value">El valor resultante de la operación.</param>
    private Result(TValue? value) : this()
    {
        Errors = value is not null ? Error.EmptyErrors : [Error.NullValue];
        _value = value;
    }

    /// <summary>
    /// Inicializa una nueva instancia de la estructura <see cref="Result{TValue}"/> con el error especificado.
    /// </summary>
    /// <param name="error">El error resultante de la operación.</param>
    private Result(Error error) : this()
    {
        Errors = !error.Equals(Error.None) ? [error] : [Error.NullValue];
    }

    /// <summary>
    /// Inicializa una nueva instancia de la estructura <see cref="Result{TValue}"/> con la colección de errores especificada.
    /// </summary>
    /// <param name="errors">La colección de errores resultantes de la operación.</param>
    private Result(ICollection<Error> errors) : this()
    {
        //Evaluar cuando la colection HasOne y es None o todos son None
        Errors = !errors.IsNullOrEmpty() ? errors : [Error.NullValue];
    }

    /// <summary>
    /// Crea una nueva instancia de la estructura <see cref="Result{TValue}"/> con el valor especificado.
    /// </summary>
    /// <param name="value">El valor resultante de la operación.</param>
    /// <returns>Una nueva instancia de la estructura <see cref="Result{TValue}"/>.</returns>
    public static Result<TValue> Success(TValue value) => new(value);

    /// <summary>
    /// Crea una nueva instancia de la estructura <see cref="Result{TValue}"/> con el error especificado.
    /// </summary>
    /// <param name="error">El error resultante de la operación.</param>
    /// <returns>Una nueva instancia de la estructura <see cref="Result{TValue}"/>.</returns>
    public static Result<TValue> Failure(Error error) => new(error);

    /// <summary>
    /// Crea una nueva instancia de la estructura <see cref="Result{TValue}"/> con la colección de errores especificada.
    /// </summary>
    /// <param name="errors">La colección de errores resultantes de la operación.</param>
    /// <returns>Una nueva instancia de la estructura <see cref="Result{TValue}"/>.</returns>
    public static Result<TValue> Failure(ICollection<Error> errors) => new(errors);

    /// <summary>
    /// Crea una nueva instancia de la estructura <see cref="Result{TValue}"/> con el valor especificado,
    /// o un resultado fallido si el valor es nulo.
    /// </summary>
    /// <param name="value">El valor resultante de la operación.</param>
    /// <returns>Una nueva instancia de la estructura <see cref="Result{TValue}"/>.</returns>
    public static Result<TValue> Create(TValue? value) => value is not null ? Success(value) : Failure(Error.NullValue);

    /// <summary>
    /// Define una conversión implícita de un valor del tipo <typeparamref name="TValue"/> a una instancia de <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="value">El valor resultante de la operación.</param>
    public static implicit operator Result<TValue>(TValue value) => new(value);

    /// <summary>
    /// Define una conversión implícita de un <see cref="Error"/> a una instancia de <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="error">El error resultante de la operación.</param>
    public static implicit operator Result<TValue>(Error error) => new(error);

    /// <summary>
    /// Define una conversión implícita de una lista de errores a una instancia de <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="errors">La lista de errores resultantes de la operación.</param>
    public static implicit operator Result<TValue>(List<Error> errors) => new(errors);

    /// <summary>
    /// Define una conversión implícita de un conjunto de errores a una instancia de <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="errors">El conjunto de errores resultantes de la operación.</param>
    public static implicit operator Result<TValue>(HashSet<Error> errors) => new(errors);

    /// <summary>
    /// Define una conversión implícita de un arreglo de errores a una instancia de <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="errors">El arreglo de errores resultantes de la operación.</param>
    public static implicit operator Result<TValue>(Error[] errors) => new(errors);
}
