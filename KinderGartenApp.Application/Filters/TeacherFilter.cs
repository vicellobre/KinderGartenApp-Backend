using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Extensions;
using KinderGartenApp.Core.Exceptions;

namespace KinderGartenApp.Application.Filters;

public class TeacherFilter
{
    private Teacher? _teacher;

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
            throw new ArgumentNullException(nameof(teacher), "Teacher cannot be null");
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
        _teacher = teacher ?? throw new ArgumentNullException(nameof(teacher), "Teacher cannot be null");
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
