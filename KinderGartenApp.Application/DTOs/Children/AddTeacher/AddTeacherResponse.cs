namespace KinderGartenApp.Application.DTOs.Children.AddStudent;

/// <summary>
/// DTO para la respuesta de añadir un estudiante a un maestro.
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
