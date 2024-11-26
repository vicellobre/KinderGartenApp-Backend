namespace KinderGartenApp.Application.DTOs.Teachers.AddStudent;

/// <summary>
/// DTO para la respuesta de añadir un estudiante a un maestro.
/// </summary>
public record class AddStudentResponse
{
    /// <summary>
    /// Identificador único del estudiante añadido.
    /// </summary>
    public Guid StudentId { get; init; }

    /// <summary>
    /// Nombre del estudiante añadido.
    /// </summary>
    public string? StudentFirstName { get; init; }

    /// <summary>
    /// Apellido del estudiante añadido.
    /// </summary>
    public string? StudentLastName { get; init; }

    /// <summary>
    /// Identificador único del maestro al que se añadió el estudiante.
    /// </summary>
    public Guid TeacherId { get; init; }

    /// <summary>
    /// Nombre del maestro.
    /// </summary>
    public string? TeacherFirstName { get; init; }

    /// <summary>
    /// Apellido del maestro.
    /// </summary>
    public string? TeacherLastName { get; init; }
}
