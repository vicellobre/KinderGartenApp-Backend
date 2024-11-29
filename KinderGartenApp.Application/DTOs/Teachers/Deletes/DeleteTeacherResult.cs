using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Errors;

namespace KinderGartenApp.Application.DTOs.Teachers.Deletes;

/// <summary>
/// DTO para la respuesta de eliminar un maestro (Teacher).
/// </summary>
public record class DeleteTeacherResult
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
    /// Operador explícito para convertir un objeto <see cref="Teacher"/> a <see cref="DeleteTeacherResult"/>.
    /// </summary>
    /// <param name="teacher">El objeto <see cref="Teacher"/> a convertir.</param>
    /// <returns>Un nuevo objeto <see cref="DeleteTeacherResult"/>.</returns>
    /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro <paramref name="teacher"/> es nulo.</exception>
    public static explicit operator DeleteTeacherResult(Teacher? teacher)
    {
        if (teacher is null)
        {
            throw new ArgumentNullException(nameof(teacher), Error.Teacher.IsNull.Message);
        }

        return new DeleteTeacherResult
        {
            Id = teacher.Id,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName
        };
    }
}
