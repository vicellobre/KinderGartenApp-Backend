using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Shared;
using KinderGartenApp.Core.Errors;
using KinderGartenApp.Core.Extensions;

namespace KinderGartenApp.Application.Validators;

/// <summary>
/// Clase estática que proporciona métodos de validación para la entidad Child.
/// </summary>
public static class ChildValidator
{
    /// <summary>
    /// Longitud máxima permitida para nombres.
    /// </summary>
    private const int MaxNamesLenght = 50;

    /// <summary>
    /// Edad mínima requerida para un niño.
    /// </summary>
    private const int MinimumYearsOld = 6;

    /// <summary>
    /// Valida los datos de un objeto Child.
    /// </summary>
    /// <param name="child">El objeto Child que se va a validar.</param>
    /// <returns>Un resultado que indica si la validación fue exitosa.</returns>
    public static Result<bool> Validate(Child child)
    {
        /// <summary>
        /// Lista para almacenar los errores encontrados durante la validación.
        /// </summary>
        List<Error> errors = [];

        if (string.IsNullOrWhiteSpace(child.FirstName))
        {
            errors.Add(Error.FirstName.IsNullOrEmpty);
        }
        else
        {
            if (child.FirstName.Length > MaxNamesLenght)
                errors.Add(Error.FirstName.TooLong(MaxNamesLenght));

            if (!child.FirstName.IsValidPersonName())
                errors.Add(Error.FirstName.InvalidSpecialCharacters);
        }

        if (string.IsNullOrWhiteSpace(child.LastName))
        {
            errors.Add(Error.FirstName.IsNullOrEmpty);
        }
        else
        {
            if (child.LastName.Length > MaxNamesLenght)
                errors.Add(Error.FirstName.TooLong(MaxNamesLenght));

            if (!child.LastName.IsValidPersonName())
                errors.Add(Error.FirstName.InvalidSpecialCharacters);
        }

        if (child.BirthDate > DateTime.Today.AddYears(-MinimumYearsOld))
            errors.Add(Error.BirthDate.InvalidAge(MinimumYearsOld));

        /// <summary>
        /// Si no hay errores devuelve un resultado exitoso, de lo contrario devuelve la lista de errores
        /// </summary>
        return errors.IsEmpty() ? Result<bool>.Success(true) : Result<bool>.Failure(errors);
    }
}
