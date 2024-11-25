using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Application.DTOs.Teachers.Update;

/// <summary>
/// DTO para el mensaje de actualizar un maestro (Teacher).
/// </summary>
public record class UpdateTeacherMessage
{
    /// <summary>
    /// Identificador único del maestro.
    /// </summary>
    public Guid Id { get; init; }

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
    /// Operador explícito para convertir un objeto <see cref="UpdateTeacherMessage"/> a <see cref="Teacher"/>.
    /// </summary>
    /// <param name="message">El objeto <see cref="UpdateTeacherMessage"/> a convertir.</param>
    /// <returns>Un nuevo objeto <see cref="Teacher"/>.</returns>
    /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro <paramref name="message"/> es nulo.</exception>
    public static explicit operator Teacher(UpdateTeacherMessage? message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message), "UpdateTeacherMessage cannot be null");
        }

        return Teacher.Create(message.Id, message.FirstName, message.LastName, message.GradeLevel);
    }
}

