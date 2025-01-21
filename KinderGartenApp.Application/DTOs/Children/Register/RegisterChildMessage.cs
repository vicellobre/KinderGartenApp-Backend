using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Errors;

namespace KinderGartenApp.Application.DTOs.Children.Register;

/// <summary>
/// DTO para el mensaje de registro de un child (Child).
/// </summary>
public record class RegisterChildMessage
{
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
    /// Id del maestro del child.
    /// </summary>
    public Guid TeacherId { get; init; }

    /// <summary>
    /// Operador explícito para convertir un objeto <see cref="RegisterChildMessage"/> a <see cref="Child"/>.
    /// </summary>
    /// <param name="child">El objeto <see cref="RegisterChildMessage"/> a convertir.</param>
    /// <returns>Un nuevo objeto <see cref="Child"/>.</returns>
    /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro <paramref name="child"/> es nulo.</exception>
    public static explicit operator Child(RegisterChildMessage? child)
    {
        if (child is null)
        {
            throw new ArgumentNullException(nameof(child), Error.ChildRequest.RegisterIsNull.Message);
        }

        return Child.Create(Guid.NewGuid(), child.FirstName, child.LastName, child.BirthDate, child.GradeLevel, child.ParentId, child.TeacherId);
    }
}
