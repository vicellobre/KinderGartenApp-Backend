namespace KinderGartenApp.Application.DTOs.Teachers.AddStudent;

/// <summary>
/// DTO para el mensaje de añadir un estudiante a un maestro.
/// </summary>
public record class AddStudentMessage
{
    /// <summary>
    /// Identificador único del maestro.
    /// </summary>
    public Guid TeacherId { get; init; }

    /// <summary>
    /// Identificador único del estudiante.
    /// </summary>
    public Guid StudentId { get; init; }
}
