using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Errors;

namespace KinderGartenApp.Application.DTOs.Children.Get;

/// <summary>
/// DTO para la respuesta de obtener un child (Child).
/// </summary>
public record GetChildResponse
{
    /// <summary>
    /// Identificador único del child.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Nombre del child.
    /// </summary>
    public string? FirstName { get; init; }

    /// <summary>
    /// Apellido del child.
    /// </summary>
    public string? LastName { get; init; }

    /// <summary>
    /// Nivel de grado del child.
    /// </summary>
    public GradeLevel GradeLevel { get; init; }

    /// <summary>
    /// Operador explícito para convertir un objeto <see cref="Child"/> a <see cref="GetChildResponse"/>.
    /// </summary>
    /// <param name="child">El objeto <see cref="Child"/> a convertir.</param>
    /// <returns>Un nuevo objeto <see cref="GetChildResponse"/>.</returns>
    /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro <paramref name="child"/> es nulo.</exception>
    public static explicit operator GetChildResponse(Child? child)
    {
        if (child is null)
        {
            throw new ArgumentNullException(nameof(child), Error.Children.IsNull.Message);
        }

        return new GetChildResponse
        {
            Id = child.Id,
            FirstName = child.FirstName,
            LastName = child.LastName,
            GradeLevel = child.GradeLevel
        };
    }
}
