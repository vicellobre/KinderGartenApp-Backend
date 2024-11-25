namespace KinderGartenApp.Application.DTOs.Teachers.Deletes;

/// <summary>
/// DTO para el mensaje de eliminar un maestro (Teacher).
/// </summary>
public record class DeleteTeacherMessage
{
    /// <summary>
    /// Identificador único del maestro.
    /// </summary>
    public Guid Id { get; init; }
}
