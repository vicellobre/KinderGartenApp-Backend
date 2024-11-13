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
        List<Error> errors = [];

        if (string.IsNullOrWhiteSpace(teacher.FirstName))
        {
            errors.Add(Error.FirstName.IsNullOrEmpty);
        }
        else
        {
            if (teacher.FirstName.Length > MaxNameLength)
            {
                errors.Add(Error.FirstName.TooLong(MaxNameLength));
            }

            if (!teacher.FirstName.IsValidPersonName())
            {
                errors.Add(Error.FirstName.InvalidSpecialCharacters);
            }
        }

        if (string.IsNullOrWhiteSpace(teacher.LastName))
        {
            errors.Add(Error.LastName.IsNullOrEmpty);
        }
        else
        {
            if (teacher.LastName.Length > MaxNameLength)
            {
                errors.Add(Error.LastName.TooLong(MaxNameLength));
            }

            if (!teacher.LastName.IsValidPersonName())
            {
                errors.Add(Error.LastName.InvalidSpecialCharacters);
            }
        }

        if (!ValidateGradeLevel(teacher.GradeLevel))
        {
            errors.Add(Error.GradeLevel.Invalid);
        }

        return errors.IsEmpty() ? Result<bool>.Success(true) : Result<bool>.Failure(errors);
    }

    /// <summary>
    /// Valida el nivel de grado del maestro.
    /// </summary>
    /// <param name="gradeLevel">El nivel de grado a validar.</param>
    /// <returns>True si es válido, de lo contrario, false.</returns>
    private static bool ValidateGradeLevel(GradeLevel gradeLevel) =>
        Enum.IsDefined(typeof(GradeLevel), gradeLevel);
}