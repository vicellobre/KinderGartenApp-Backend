using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Errors;

namespace KinderGartenApp.Application.DTOs.Children.Update;

/// <summary>
/// DTO para la respuesta de actualizar un niño (Child).
/// </summary>
public record UpdateChildResponse
{
    /// <summary>
    /// Identificador único del niño.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Nombre del niño.
    /// </summary>
    public string? FirstName { get; init; }

    /// <summary>
    /// Apellido del niño.
    /// </summary>
    public string? LastName { get; init; }

    /// <summary>
    /// fecha de nacimiento del niño.
    /// </summary>
    public DateTime BirthDate { get; init; }

    /// <summary>
    /// Nivel de grado del niño.
    /// </summary>
    public GradeLevel GradeLevel { get; init; }

    /// <summary>
    /// Operador explícito para convertir un objeto <see cref="Child"/> a <see cref="UpdateChildResponse"/>.
    /// </summary>
    /// <param name="child">El objeto <see cref="Child"/> a convertir.</param>
    /// <returns>Un nuevo objeto <see cref="UpdateChildResponse"/>.</returns>
    /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro <paramref name="child"/> es nulo.</exception>
    public static explicit operator UpdateChildResponse(Child? child)
    {
        if (child is null)
        {
            throw new ArgumentNullException(nameof(child), Error.Children.IsNull.Message);
        }

        return new UpdateChildResponse
        {
            Id = child.Id,
            FirstName = child.FirstName,
            LastName = child.LastName,
            BirthDate = child.BirthDate,
            GradeLevel = child.GradeLevel
        };
    }
}
