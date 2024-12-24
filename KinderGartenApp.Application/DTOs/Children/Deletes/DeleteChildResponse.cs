using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Errors;

namespace KinderGartenApp.Application.DTOs.Children.Deletes;

/// <summary>
/// DTO para la respuesta de eliminar un niño (Child).
/// </summary>
public record class DeleteChildResponse
{
    /// <summary>
    /// Identificador único del niño eliminado.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Nombre del niño eliminado.
    /// </summary>
    public string? FirstName { get; init; }

    /// <summary>
    /// Apellido del niño eliminado.
    /// </summary>
    public string? LastName { get; init; }

    /// <summary>
    /// Operador explícito para convertir un objeto <see cref="Child"/> a <see cref="DeleteChildResponse"/>.
    /// </summary>
    /// <param name="child">El objeto <see cref="Child"/> a convertir.</param>
    /// <returns>Un nuevo objeto <see cref="DeleteChildResponse"/>.</returns>
    /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro <paramref name="child"/> es nulo.</exception>
    public static explicit operator DeleteChildResponse(Child? child)
    {
        if (child is null)
        {
            throw new ArgumentNullException(nameof(child), Error.Children.IsNull.Message);
        }

        return new DeleteChildResponse
        {
            Id = child.Id,
            FirstName = child.FirstName,
            LastName = child.LastName
        };
    }
}
