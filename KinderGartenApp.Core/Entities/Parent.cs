using KinderGartenApp.Core.Primitives;
using KinderGartenApp.Core.Validators;
using System.Collections.ObjectModel;

namespace KinderGartenApp.Core.Entities;

public class Parent : Entity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    //[RegularExpression("^[0-9]{10}$", ErrorMessage = "El número telefónico debe tener diez (10) dígitos")]
    public string? Phone { get; set; }

    public Collection<Child>? Sons { get; set; }

    private Parent(Guid id, string? firstName, string? lastName, string? email, string? password, string? phone) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        Phone = phone;
    }

    public static Parent Create(Guid id, string? firstName, string? lastName, string? email, string? password, string? phone)
    {
        return new(id, firstName, lastName, email, password, phone);
    }

    public bool AddChild(Child child)
    {
        Sons ??= new();
        if (!Sons.Any(x => x == child) && ChildValidator.Validate(child).isValid)
        {
            Sons.Add(child);
            return true;
        }
        return false;
    }
}