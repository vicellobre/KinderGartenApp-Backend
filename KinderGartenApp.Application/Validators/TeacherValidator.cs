using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Errors;
using KinderGartenApp.Core.Extensions;
using KinderGartenApp.Core.Shared;

namespace KinderGartenApp.Application.Validators;

/// <summary>
/// Clase que proporciona métodos de validación para la entidad Teacher.
/// </summary>
public static class TeacherValidator
{
    private const int MaxNameLength = 30; // Longitud máxima para nombres y apellidos

    /// <summary>
    /// Valida los datos de un maestro.
    /// </summary>
    /// <param name="teacher">El objeto Teacher a validar.</param>
    /// <returns>True si es válido, de lo contrario, false.</returns>
    public static Result<bool> Validate(Teacher teacher)
    {
        if (string.IsNullOrWhiteSpace(teacher.FirstName))
        {
            return Result<bool>.Failure(Error.FirstName.IsNullOrEmpty);
        }

        if (teacher.FirstName.Length > MaxNameLength)
        {
            return Result<bool>.Failure(Error.FirstName.TooLong(MaxNameLength));
        }

        if (!teacher.FirstName.IsValidPersonName())
        {
            return Result<bool>.Failure(Error.FirstName.InvalidSpecialCharacters);
        }

        if (string.IsNullOrWhiteSpace(teacher.LastName))
        {
            return Result<bool>.Failure(Error.LastName.IsNullOrEmpty);
        }

        if (teacher.LastName.Length > MaxNameLength)
        {
            return Result<bool>.Failure(Error.LastName.TooLong(MaxNameLength));
        }

        if (!teacher.LastName.IsValidPersonName())
        {
            return Result<bool>.Failure(Error.LastName.InvalidSpecialCharacters);
        }

        if (!ValidateGradeLevel(teacher.GradeLevel))
        {
            return Result<bool>.Failure(Error.GradeLevel.Invalid);
        }

        return Result<bool>.Success(true);
    }

    /// <summary>
    /// Valida el nivel de grado del maestro.
    /// </summary>
    /// <param name="gradeLevel">El nivel de grado a validar.</param>
    /// <returns>True si es válido, de lo contrario, false.</returns>
    private static bool ValidateGradeLevel(GradeLevel gradeLevel) =>
        Enum.IsDefined(typeof(GradeLevel), gradeLevel);
}