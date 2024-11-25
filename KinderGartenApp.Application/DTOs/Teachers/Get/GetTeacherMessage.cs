namespace KinderGartenApp.Application.DTOs.Teachers.Get;

/// <summary>
/// DTO para el mensaje de obtener un maestro (Teacher).
/// </summary>
public record class GetTeacherMessage
{
    /// <summary>
    /// Identificador único del maestro.
    /// </summary>
    public Guid Id { get; init; }
}
