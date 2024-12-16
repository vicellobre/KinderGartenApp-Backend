using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Extensions;
using KinderGartenApp.Core.Exceptions;
using KinderGartenApp.Core.Errors;

namespace KinderGartenApp.Application.Filters;

public class ChildFilter
{
    private Child? _child;

    public ChildFilter() { }

    /// <summary>
    /// Normaliza los nombres y apellidos del objeto Child.
    /// </summary>
    /// <param name="child">El objeto Child a normalizar.</param>
    /// <returns>El objeto Child normalizado.</returns>
    /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro child es nulo.</exception>
    public static Child Normalize(Child? child)
    {
        if (child is null)
        {
            throw new ArgumentNullException(nameof(child), Error.Child.IsNull.Message);
        }

        return new ChildFilter()
                .Set(child)
                .NormalizeFirstName()
                .NormalizeLastName()
                .Get();
    }

    /// <summary>
    /// Obtiene el objeto Child modificado.
    /// </summary>
    /// <returns>El objeto Child modificado.</returns>
    /// <exception cref="MissingChildException">Se lanza cuando el objeto Child no ha sido seteado.</exception>
    public Child Get()
    {
        if (_child is null)
        {
            throw new MissingChildException();
        }

        return _child;
    }

    /// <summary>
    /// Inyecta un objeto Child en la clase ChildFilter.
    /// </summary>
    /// <param name="child">El objeto Child a inyectar.</param>
    /// <returns>La instancia modificada de ChildFilter.</returns>
    /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro child es nulo.</exception>
    public ChildFilter Set(Child child)
    {
        _child = child ?? throw new ArgumentNullException(nameof(child), Error.Child.IsNull.Message);
        return this;
    }

    /// <summary>
    /// Normaliza el nombre del profesor.
    /// </summary>
    /// <returns>La instancia modificada de ChildFilter.</returns>
    /// <exception cref="MissingChildException">Se lanza cuando el objeto Child no ha sido seteado.</exception>
    public ChildFilter NormalizeFirstName()
    {
        if (_child is null)
        {
            throw new MissingChildException();
        }

        _child.FirstName = string.IsNullOrWhiteSpace(_child.FirstName) ? string.Empty : _child.FirstName.CapitalizeWords();
        return this;
    }

    /// <summary>
    /// Normaliza el apellido del profesor.
    /// </summary>
    /// <returns>La instancia modificada de ChildFilter.</returns>
    /// <exception cref="MissingChildException">Se lanza cuando el objeto Child no ha sido seteado.</exception>
    public ChildFilter NormalizeLastName()
    {
        if (_child is null)
        {
            throw new MissingChildException();
        }

        _child.LastName = string.IsNullOrWhiteSpace(_child.LastName) ? string.Empty : _child.LastName.CapitalizeWords();
        return this;
    }
}
