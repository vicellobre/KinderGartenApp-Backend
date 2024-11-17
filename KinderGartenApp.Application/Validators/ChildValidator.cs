using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Shared;
using KinderGartenApp.Core.Errors;
using System.Text.RegularExpressions;
using KinderGartenApp.Core.Extensions;

namespace KinderGartenApp.Application.Validators;

public static class ChildValidator
{
    private const int MaxNamesLenght = 50;
    private const int MinimumYearsOld = 6;

    public static Result<bool> Validate(Child child)
    {
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

        return errors.IsEmpty() ? Result<bool>.Success(true) : Result<bool>.Failure(errors);
    }
}
