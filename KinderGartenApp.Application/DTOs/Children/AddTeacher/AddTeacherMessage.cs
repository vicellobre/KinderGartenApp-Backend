namespace KinderGartenApp.Application.DTOs.Children.AddTeacher;

/// <summary>
/// DTO para el mensaje de añadir un maestro a un niño.
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
