using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Errors;

namespace KinderGartenApp.Application.DTOs.Children.Update;

/// <summary>
/// DTO para el mensaje de actualizar un niño (Child).
/// </summary>
public record class UpdateChildMessage
{
    /// <summary>
    /// Identificador único del niño.
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
    /// fecha de nacimiento del child.
    /// </summary>
    public DateTime BirthDate { get; init; }

    /// <summary>
    /// Nivel de grado del child.
    /// </summary>
    public GradeLevel GradeLevel { get; init; }

    /// <summary>
    /// Id del padre del child.
    /// </summary>
    public Guid ParentId { get; init; }

    /// <summary>
    /// Id del niño del child.
    /// </summary>
    public Guid TeacherId { get; init; }

    /// <summary>
    /// Operador explícito para convertir un objeto <see cref="UpdateChildMessage"/> a <see cref="Child"/>.
    /// </summary>
    /// <param name="message">El objeto <see cref="UpdateChildMessage"/> a convertir.</param>
    /// <returns>Un nuevo objeto <see cref="Child"/>.</returns>
    /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro <paramref name="message"/> es nulo.</exception>
    public static explicit operator Child(UpdateChildMessage? message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message), Error.ChildRequest.UpdateIsNull.Message);
        }
        return Child.Create(message.Id, message.FirstName, message.LastName, message.BirthDate, message.GradeLevel, message.ParentId, message.TeacherId);
    }
}

