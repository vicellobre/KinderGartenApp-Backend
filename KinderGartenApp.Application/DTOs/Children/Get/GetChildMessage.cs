namespace KinderGartenApp.Application.DTOs.Children.Get;

/// <summary>
/// DTO para el mensaje de obtener un maestro (Child).
/// </summary>
public record class GetChildMessage
{
    /// <summary>
    /// Identificador único del maestro.
    /// </summary>
    public Guid Id { get; init; }
}
