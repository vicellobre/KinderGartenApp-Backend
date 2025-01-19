using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Extensions;
using KinderGartenApp.Core.Exceptions;
using KinderGartenApp.Core.Errors;

namespace KinderGartenApp.Application.Filters;

/// <summary>
/// Clase para aplicar filtros y normalizar propiedades de objetos Teacher.
/// </summary>
public class TeacherFilter
{
    /// <summary>
    /// Instancia privada del objeto Teacher.
    /// </summary>
    private Teacher? _teacher;

    /// <summary>
    /// Constructor por defecto de la clase TeacherFilter.
    /// </summary>
    public TeacherFilter() { }

    /// <summary>
    /// Normaliza los nombres y apellidos del objeto Teacher.
    /// </summary>
    /// <param name="teacher">El objeto Teacher a normalizar.</param>
    /// <returns>El objeto Teacher normalizado.</returns>
    /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro teacher es nulo.</exception>
    public static Teacher Normalize(Teacher? teacher)
    {
        if (teacher is null)
        {
            throw new ArgumentNullException(nameof(teacher), Error.Teacher.IsNull.Message);
        }

        return new TeacherFilter()
                .Set(teacher)
                .NormalizeFirstName()
                .NormalizeLastName()
                .Get();
    }

    /// <summary>
    /// Obtiene el objeto Teacher modificado.
    /// </summary>
    /// <returns>El objeto Teacher modificado.</returns>
    /// <exception cref="MissingTeacherException">Se lanza cuando el objeto Teacher no ha sido seteado.</exception>
    public Teacher Get()
    {
        if (_teacher is null)
        {
            throw new MissingTeacherException();
        }

        return _teacher;
    }

    /// <summary>
    /// Inyecta un objeto Teacher en la clase TeacherFilter.
    /// </summary>
    /// <param name="teacher">El objeto Teacher a inyectar.</param>
    /// <returns>La instancia modificada de TeacherFilter.</returns>
    /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro teacher es nulo.</exception>
    public TeacherFilter Set(Teacher teacher)
    {
        _teacher = teacher ?? throw new ArgumentNullException(nameof(teacher), Error.Teacher.IsNull.Message);
        return this;
    }

    /// <summary>
    /// Normaliza el nombre del profesor.
    /// </summary>
    /// <returns>La instancia modificada de TeacherFilter.</returns>
    /// <exception cref="MissingTeacherException">Se lanza cuando el objeto Teacher no ha sido seteado.</exception>
    public TeacherFilter NormalizeFirstName()
    {
        if (_teacher is null)
        {
            throw new MissingTeacherException();
        }

        _teacher.FirstName = string.IsNullOrWhiteSpace(_teacher.FirstName) ? string.Empty : _teacher.FirstName.CapitalizeWords();
        return this;
    }

    /// <summary>
    /// Normaliza el apellido del profesor.
    /// </summary>
    /// <returns>La instancia modificada de TeacherFilter.</returns>
    /// <exception cref="MissingTeacherException">Se lanza cuando el objeto Teacher no ha sido seteado.</exception>
    public TeacherFilter NormalizeLastName()
    {
        if (_teacher is null)
        {
            throw new MissingTeacherException();
        }

        _teacher.LastName = string.IsNullOrWhiteSpace(_teacher.LastName) ? string.Empty : _teacher.LastName.CapitalizeWords();
        return this;
    }
}
