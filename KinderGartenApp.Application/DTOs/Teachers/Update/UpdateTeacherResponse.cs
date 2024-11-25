﻿using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Application.DTOs.Teachers.Update;

/// <summary>
/// DTO para la respuesta de actualizar un maestro (Teacher).
/// </summary>
public record UpdateTeacherResponse
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
    /// Operador explícito para convertir un objeto <see cref="Teacher"/> a <see cref="UpdateTeacherResponse"/>.
    /// </summary>
    /// <param name="teacher">El objeto <see cref="Teacher"/> a convertir.</param>
    /// <returns>Un nuevo objeto <see cref="UpdateTeacherResponse"/>.</returns>
    /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro <paramref name="teacher"/> es nulo.</exception>
    public static explicit operator UpdateTeacherResponse(Teacher? teacher)
    {
        if (teacher is null)
        {
            throw new ArgumentNullException(nameof(teacher), "Teacher cannot be null");
        }

        return new UpdateTeacherResponse
        {
            Id = teacher.Id,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            GradeLevel = teacher.GradeLevel
        };
    }
}
