using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Shared;
using KinderGartenApp.Core.Errors;
using KinderGartenApp.Core.Extensions;

namespace KinderGartenApp.Application.Validators;

public class ParentValidator
{
    private const int MaxNamesLenght = 50;
    private const int MaxEmailLenght = 70;
    private const int MinEmailLenght = 10;
    private const int MaxPasswordLenght = 100;
    private const int MinPasswordLenght = 8;

    public static Result<bool> Validate(Parent parent)
    {
        /// <summary>
        /// Lista para almacenar los errores encontrados durante la validación.
        /// </summary>
        List<Error> errors = [];

        //Validaciones de FirstName
        if (string.IsNullOrWhiteSpace(parent.FirstName))
        {
            errors.Add(Error.FirstName.IsNullOrEmpty);
        }
        else
        {
            if (parent.FirstName.Length > MaxNamesLenght)
                errors.Add(Error.FirstName.TooLong(MaxNamesLenght));

            if (!parent.FirstName.IsValidPersonName())
                errors.Add(Error.FirstName.InvalidSpecialCharacters);
        }

        //Validaciones de LastName
        if (string.IsNullOrWhiteSpace(parent.LastName))
        {
            errors.Add(Error.FirstName.IsNullOrEmpty);
        }
        else
        {
            if (parent.LastName.Length > MaxNamesLenght)
                errors.Add(Error.FirstName.TooLong(MaxNamesLenght));

            if (!parent.LastName.IsValidPersonName())
                errors.Add(Error.FirstName.InvalidSpecialCharacters);
        }

        //Validaciones de Email
        if (string.IsNullOrWhiteSpace(parent.Email) || parent.Email.Contains(' '))
        {
            errors.Add(Error.Email.IsNullOrEmpty);
        }
        else
        {
            if (parent.Email.Length > MaxEmailLenght)
                errors.Add(Error.Email.TooLong(MaxEmailLenght));
            else if (parent.Email.Length < MinEmailLenght)
                errors.Add(Error.Email.TooShort(MinEmailLenght));

            if (!parent.Email.IsValidEmail())
                errors.Add(Error.Email.InvalidFormat);
        }

        //Validaciones de Password
        if (string.IsNullOrWhiteSpace(parent.Password))
        {
            errors.Add(Error.Password.IsNullOrEmpty);
        }
        else
        {
            if (parent.Password.Length > MaxPasswordLenght)
                errors.Add(Error.Password.TooLong(MaxPasswordLenght));
            else if (parent.Password.Length < MinPasswordLenght)
                errors.Add(Error.Password.TooShort(MinPasswordLenght));
        }

        //Validaciones para Phone
        if (string.IsNullOrWhiteSpace(parent.Phone) || parent.Phone.Contains(' '))
        {
            errors.Add(Error.Phone.IsNullOrEmpty);
        }
        else if (!parent.Phone.IsValidPhone())
        {
            errors.Add(Error.Phone.InvalidFormat);
        }

        return errors.IsEmpty() ? Result<bool>.Success(true) : Result<bool>.Failure(errors);
    }
}