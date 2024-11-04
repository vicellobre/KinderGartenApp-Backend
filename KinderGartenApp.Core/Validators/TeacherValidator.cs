using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using System.Text.RegularExpressions;

namespace KinderGartenApp.Core.Validators;

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
    public static bool Validate(Teacher teacher) =>
        ValidateFirstName(teacher.FirstName) &&
        ValidateLastName(teacher.LastName) &&
        ValidateGradeLevel(teacher.GradeLevel);

    /// <summary>
    /// Valida el nombre del maestro.
    /// </summary>
    /// <param name="firstName">El nombre del maestro a validar.</param>
    /// <returns>True si es válido, de lo contrario, false.</returns>
    private static bool ValidateFirstName(string? firstName) =>
        !string.IsNullOrWhiteSpace(firstName) &&
        firstName.Length <= MaxNameLength &&
        IsAlphabetic(firstName);

    /// <summary>
    /// Valida el apellido del maestro.
    /// </summary>
    /// <param name="lastName">El apellido del maestro a validar.</param>
    /// <returns>True si es válido, de lo contrario, false.</returns>
    private static bool ValidateLastName(string? lastName) =>
        !string.IsNullOrWhiteSpace(lastName) &&
        lastName.Length <= MaxNameLength &&
        IsAlphabetic(lastName);

    /// <summary>
    /// Valida el nivel de grado del maestro.
    /// </summary>
    /// <param name="gradeLevel">El nivel de grado a validar.</param>
    /// <returns>True si es válido, de lo contrario, false.</returns>
    private static bool ValidateGradeLevel(GradeLevel gradeLevel) =>
        Enum.IsDefined(typeof(GradeLevel), gradeLevel);

    /// <summary>
    /// Verifica si una cadena contiene solo caracteres alfabéticos (incluyendo acentos y caracteres especiales).
    /// </summary>
    /// <param name="input">Cadena a validar.</param>
    /// <returns>True si solo contiene letras, de lo contrario, false.</returns>
    private static bool IsAlphabetic(string input) => Regex.IsMatch(input, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ]+$");
}