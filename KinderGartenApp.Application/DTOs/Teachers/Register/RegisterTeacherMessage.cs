using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Entities;

namespace KinderGartenApp.Application.DTOs.Teachers.Register;

/// <summary>
/// DTO para el mensaje de registro de un maestro (Teacher).
/// </summary>
public record class RegisterTeacherMessage
{
    /// <summary>
    /// Nombre del maestro.
    /// </summary>
    public string? FirstName { get; init; }

    /// <summary>
    /// Apellido del maestro.
    /// </summary>
    public string? LastName { get; init; }

    /// <summary>
    /// Nivel de grado del maestro.
    /// </summary>
    public GradeLevel GradeLevel { get; init; }

    /// <summary>
    /// Operador explícito para convertir un objeto <see cref="RegisterTeacherMessage"/> a <see cref="Teacher"/>.
    /// </summary>
    /// <param name="teacher">El objeto <see cref="RegisterTeacherMessage"/> a convertir.</param>
    /// <returns>Un nuevo objeto <see cref="Teacher"/>.</returns>
    /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro <paramref name="teacher"/> es nulo.</exception>
    public static explicit operator Teacher(RegisterTeacherMessage teacher)
    {
        if (teacher is null)
        {
            throw new ArgumentNullException(nameof(teacher), "RegisterTeacherMessage cannot be null");
        }

        return Teacher.Create(Guid.NewGuid(), teacher.FirstName, teacher.LastName, teacher.GradeLevel);
    }
}
