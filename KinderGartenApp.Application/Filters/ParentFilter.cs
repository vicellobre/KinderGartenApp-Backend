using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Extensions;
using KinderGartenApp.Core.Exceptions;
using KinderGartenApp.Core.Errors;

namespace KinderGartenApp.Application.Filters;

public class ParentFilter
{
    private Parent? _parent;

    public ParentFilter() { }

    /// <summary>
    /// Normaliza los nombres y apellidos del objeto Parent.
    /// </summary>
    /// <param name="parent">El objeto Parent a normalizar.</param>
    /// <returns>El objeto Parent normalizado.</returns>
    /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro parent es nulo.</exception>
    public static Parent Normalize(Parent? parent)
    {
        if (parent is null)
        {
            throw new ArgumentNullException(nameof(parent), Error.Parent.IsNull.Message);
        }

        return new ParentFilter()
                .Set(parent)
                .NormalizeFirstName()
                .NormalizeLastName()
                .Get();
    }

    /// <summary>
    /// Obtiene el objeto Parent modificado.
    /// </summary>
    /// <returns>El objeto Parent modificado.</returns>
    /// <exception cref="MissingParentException">Se lanza cuando el objeto Parent no ha sido seteado.</exception>
    public Parent Get()
    {
        if (_parent is null)
        {
            throw new MissingParentException();
        }

        return _parent;
    }

    /// <summary>
    /// Inyecta un objeto Parent en la clase ParentFilter.
    /// </summary>
    /// <param name="parent">El objeto Parent a inyectar.</param>
    /// <returns>La instancia modificada de ParentFilter.</returns>
    /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro parent es nulo.</exception>
    public ParentFilter Set(Parent parent)
    {
        _parent = parent ?? throw new ArgumentNullException(nameof(parent), Error.Parent.IsNull.Message);
        return this;
    }

    /// <summary>
    /// Normaliza el nombre del profesor.
    /// </summary>
    /// <returns>La instancia modificada de ParentFilter.</returns>
    /// <exception cref="MissingParentException">Se lanza cuando el objeto Parent no ha sido seteado.</exception>
    public ParentFilter NormalizeFirstName()
    {
        if (_parent is null)
        {
            throw new MissingParentException();
        }

        _parent.FirstName = string.IsNullOrWhiteSpace(_parent.FirstName) ? string.Empty : _parent.FirstName.CapitalizeWords();
        return this;
    }

    /// <summary>
    /// Normaliza el apellido del profesor.
    /// </summary>
    /// <returns>La instancia modificada de ParentFilter.</returns>
    /// <exception cref="MissingParentException">Se lanza cuando el objeto Parent no ha sido seteado.</exception>
    public ParentFilter NormalizeLastName()
    {
        if (_parent is null)
        {
            throw new MissingParentException();
        }

        _parent.LastName = string.IsNullOrWhiteSpace(_parent.LastName) ? string.Empty : _parent.LastName.CapitalizeWords();
        return this;
    }

    /// <summary>
    /// Normaliza el email del profesor.
    /// </summary>
    /// <returns>La instancia modificada de ParentFilter.</returns>
    /// <exception cref="MissingParentException">Se lanza cuando el objeto Parent no ha sido seteado.</exception>
    public ParentFilter NormalizeEmail()
    {
        if (_parent is null)
        {
            throw new MissingParentException();
        }

        _parent.Email = string.IsNullOrWhiteSpace(_parent.Email) ? string.Empty : _parent.Email.CapitalizeWords().ToLower();
        return this;
    }
}
