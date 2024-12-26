namespace KinderGartenApp.Application.DTOs.Children.AddParent;

/// <summary>
/// DTO para la respuesta de añadir un padre a un niño.
/// </summary>
public record class AddParentResponse
{
    /// <summary>
    /// Identificador único del padre añadido.
    /// </summary>
    public Guid TeacherId { get; init; }

    /// <summary>
    /// Nombre del padre añadido.
    /// </summary>
    public string? TeacherFirstName { get; init; }

    /// <summary>
    /// Apellido del padre añadido.
    /// </summary>
    public string? TeacherLastName { get; init; }

    /// <summary>
    /// Identificador único del niño al que se añadió el padre.
    /// </summary>
    public Guid ChildId { get; init; }

    /// <summary>
    /// Nombre del niño.
    /// </summary>
    public string? ChildFirstName { get; init; }

    /// <summary>
    /// Apellido del niño.
    /// </summary>
    public string? ChildLastName { get; init; }
}
