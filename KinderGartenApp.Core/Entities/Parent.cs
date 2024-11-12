using KinderGartenApp.Core.Primitives;
using System.Collections.ObjectModel;

namespace KinderGartenApp.Core.Entities;

/// <summary>
/// Representa a un padre/madre con propiedades de nombre, correo electrónico, contraseña,
/// número de teléfono y una colección de hijos.
/// </summary>
public class Parent : Entity
{
    /// <summary>
    /// Obtiene o establece el primer nombre del padre/madre.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Obtiene o establece el apellido del padre/madre.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Obtiene o establece el correo electrónico del padre/madre.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Obtiene o establece la contraseña del padre/madre.
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Obtiene o establece el número de teléfono del padre/madre.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Obtiene o establece la colección de hijos del padre/madre.
    /// </summary>
    public Collection<Child> Sons { get; set; }

    /// <summary>
    /// Constructor privado para inicializar una nueva instancia de la clase <see cref="Parent"/> 
    /// con los valores especificados.
    /// </summary>
    /// <param name="id">Identificador único del padre/madre.</param>
    /// <param name="firstName">Primer nombre del padre/madre.</param>
    /// <param name="lastName">Apellido del padre/madre.</param>
    /// <param name="email">Correo electrónico del padre/madre.</param>
    /// <param name="password">Contraseña del padre/madre.</param>
    /// <param name="phone">Número de teléfono del padre/madre.</param>
    private Parent(Guid id, string? firstName, string? lastName, string? email, string? password, string? phone) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        Phone = phone;
        Sons = [];
    }

    /// <summary>
    /// Crea una nueva instancia de la clase <see cref="Parent"/> con los valores especificados.
    /// </summary>
    /// <param name="id">Identificador único del padre/madre.</param>
    /// <param name="firstName">Primer nombre del padre/madre.</param>
    /// <param name="lastName">Apellido del padre/madre.</param>
    /// <param name="email">Correo electrónico del padre/madre.</param>
    /// <param name="password">Contraseña del padre/madre.</param>
    /// <param name="phone">Número de teléfono del padre/madre.</param>
    /// <returns>Una nueva instancia de la clase <see cref="Parent"/>.</returns>
    public static Parent Create(Guid id, string? firstName, string? lastName, string? email, string? password, string? phone)
    {
        return new(id, firstName, lastName, email, password, phone);
    }

    /// <summary>
    /// Agrega un hijo a la colección de hijos del padre/madre.
    /// </summary>
    /// <param name="child">El hijo a agregar.</param>
    /// <returns>Devuelve <c>true</c> si el hijo se agregó correctamente; de lo contrario, <c>false</c>.</returns>
    public bool AddChild(Child child)
    {
        if (child is null)
        {
            return false;
        }

        if (Sons.Contains(child))
        {
            return false;
        }

        Sons.Add(child);
        return true;
    }
}
