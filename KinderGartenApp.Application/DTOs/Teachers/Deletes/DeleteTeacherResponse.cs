using KinderGartenApp.Core.Entities;

namespace KinderGartenApp.Application.DTOs.Teachers.Deletes;

/// <summary>
/// DTO para la respuesta de eliminar un maestro (Teacher).
/// </summary>
public record class DeleteTeacherResponse
{
    /// <summary>
    /// Identificador único del maestro eliminado.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Nombre del maestro eliminado.
    /// </summary>
    public string? FirstName { get; init; }

    /// <summary>
    /// Apellido del maestro eliminado.
    /// </summary>
    public string? LastName { get; init; }

    /// <summary>
    /// Operador explícito para convertir un objeto <see cref="Teacher"/> a <see cref="DeleteTeacherResponse"/>.
    /// </summary>
    /// <param name="teacher">El objeto <see cref="Teacher"/> a convertir.</param>
    /// <returns>Un nuevo objeto <see cref="DeleteTeacherResponse"/>.</returns>
    /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro <paramref name="teacher"/> es nulo.</exception>
    public static explicit operator DeleteTeacherResponse(Teacher? teacher)
    {
        if (teacher is null)
        {
            throw new ArgumentNullException(nameof(teacher), "Teacher cannot be null");
        }

        return new DeleteTeacherResponse
        {
            Id = teacher.Id,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName
        };
    }
}
