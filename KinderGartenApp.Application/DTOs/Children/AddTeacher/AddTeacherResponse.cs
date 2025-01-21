namespace KinderGartenApp.Application.DTOs.Children.AddTeacher;

/// <summary>
/// DTO para la respuesta de añadir un maestro a un niño.
/// </summary>
public record class AddTeacherResponse
{
    /// <summary>
    /// Identificador único del profesor añadido.
    /// </summary>
    public Guid TeacherId { get; init; }

    /// <summary>
    /// Nombre del profesor añadido.
    /// </summary>
    public string? TeacherFirstName { get; init; }

    /// <summary>
    /// Apellido del profesor añadido.
    /// </summary>
    public string? TeacherLastName { get; init; }

    /// <summary>
    /// Identificador único del niño al que se añadió el profesor.
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
