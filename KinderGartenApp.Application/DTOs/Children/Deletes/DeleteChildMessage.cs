namespace KinderGartenApp.Application.DTOs.Children.Deletes;

/// <summary>
/// DTO para el mensaje de eliminar un niño (Child).
/// </summary>
public record class DeleteChildMessage
{
    /// <summary>
    /// Identificador único del niño.
    /// </summary>
    public Guid Id { get; init; }
}
