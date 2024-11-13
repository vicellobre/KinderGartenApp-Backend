using KinderGartenApp.Core.Entities;
using System.Text.RegularExpressions;

namespace KinderGartenApp.Application.Validators;

public class ParentValidator
{
    private const int MaxNamesLenght = 50;
    private const int MaxEmailLenght = 70;
    private const int MinEmailLenght = 10;
    private const int MaxPasswordLenght = 100;
    private const int MinPasswordLenght = 8;

    public static (bool isValid, string? message) Validate(Parent parent)
    {
        Regex spetialCharacters = new(@"^[a-zA-Z\s]+$");
        Regex email = new(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        Regex phone = new(@"^\d{10}$");

        //Validaciones de FirstName
        if (string.IsNullOrWhiteSpace(parent.FirstName) || parent.FirstName.StartsWith(' ') || parent.FirstName.EndsWith(' '))
            return (false, "The name cannot be empty or start or end with a blank space.");

        if (parent.FirstName.Length > MaxNamesLenght)
            return (false, $"The name cannot exceed {MaxNamesLenght} characters.");

        if (!spetialCharacters.IsMatch(parent.FirstName))
            return (false, "The name cannot contain special characters.");

        //Validaciones de LastName
        if (string.IsNullOrWhiteSpace(parent.LastName) || parent.LastName.StartsWith(' ') || parent.LastName.EndsWith(' '))
            return (false, "The last name cannot be empty or start or end with a blank space.");

        if (parent.LastName.Length > MaxNamesLenght)
            return (false, $"The last name cannot exceed {MaxNamesLenght} characters.");

        if (!spetialCharacters.IsMatch(parent.LastName))
            return (false, "The last name cannot contain special characters.");

        //Validaciones de Email
        if (string.IsNullOrWhiteSpace(parent.Email) || parent.Email.Contains(' '))
            return (false, "The email cannot be empty or contain a blank space.");

        if (parent.Email.Length > MaxEmailLenght)
            return (false, $"The email lenght cannot exceed {MaxEmailLenght} characters.");

        if (parent.Email.Length < MinEmailLenght)
            return (false, $"The email lenght cannot be under {MinEmailLenght} characters.");

        if (!email.IsMatch(parent.Email))
            return (false, "Invalid email format.");

        //Validaciones de Password
        if (string.IsNullOrWhiteSpace(parent.Password) || parent.Password.Contains(' '))
            return (false, "The password cannot be empty or contain a blank space.");

        if (parent.Password.Length > MaxPasswordLenght)
            return (false, $"The password lenght cannot exceed {MaxPasswordLenght} characters.");

        if (parent.Password.Length < MinPasswordLenght)
            return (false, $"The password lenght cannot be under {MinPasswordLenght} characters.");

        //Validaciones para Phone
        if (string.IsNullOrWhiteSpace(parent.Phone) || parent.Phone.Contains(' '))
            return (false, "The phone cannot be empty or contain a blank space.");

        if (!phone.IsMatch(parent.Phone))
            return (false, "Invalid phone format.");

        return (true, string.Empty);
    }
}