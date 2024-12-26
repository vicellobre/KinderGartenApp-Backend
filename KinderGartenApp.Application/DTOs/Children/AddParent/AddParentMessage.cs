namespace KinderGartenApp.Application.DTOs.Children.AddParent;

/// <summary>
/// DTO para el mensaje de añadir un padre a un niño.
/// </summary>
public record class AddParentMessage
{
    /// <summary>
    /// Identificador único del padre.
    /// </summary>
    public Guid ParentId { get; init; }

    /// <summary>
    /// Identificador único del niño.
    /// </summary>
    public Guid ChildId { get; init; }
}
