namespace KinderGartenApp.Application.DTOs.Children.AddStudent;

/// <summary>
/// DTO para el mensaje de añadir un estudiante a un maestro.
/// </summary>
public record class AddTeacherMessage
{
    /// <summary>
    /// Identificador único del maestro.
    /// </summary>
    public Guid TeacherId { get; init; }

    /// <summary>
    /// Identificador único del niño.
    /// </summary>
    public Guid ChildId { get; init; }
}
