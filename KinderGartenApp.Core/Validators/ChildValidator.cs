using KinderGartenApp.Core.Entities;
using System.Text.RegularExpressions;

namespace KinderGartenApp.Core.Validators;

public static class ChildValidator
{
    private const int maxNamesLenght = 50;

    public static (bool isValid, string? message) Validate(Child child)
    {
        Regex regex = new Regex(@"^[a-zA-Z\s]+$");

        if (string.IsNullOrWhiteSpace(child.FirstName) || child.FirstName.StartsWith(' ') || child.FirstName.EndsWith(' '))
            return (false, "The name cannot be empty or start or end with a blank space.");

        if (child.FirstName.Length > maxNamesLenght)
            return (false, $"The name cannot exceed {maxNamesLenght} characters.");

        if (!regex.IsMatch(child.FirstName))
            return (false, "The name cannot contain special characters.");

        if (string.IsNullOrWhiteSpace(child.LastName) || child.LastName.StartsWith(' ') || child.LastName.EndsWith(' '))
            return (false, "The last name cannot be empty or start or end with a blank space.");

        if (child.LastName.Length > maxNamesLenght)
            return (false, $"The last name cannot exceed {maxNamesLenght} characters.");

        if (!regex.IsMatch(child.LastName))
            return (false, "The last name cannot contain special characters.");

        if (child.BirthDate > DateTime.Today.AddYears(-6))
            return (false, "The birth date cannot be less than 6 years ago.");

        if (child.ParentId <= 0)
            return (false, "The parent ID cannot be less than or equal to 0.");

        return (true, string.Empty);
    }
}
