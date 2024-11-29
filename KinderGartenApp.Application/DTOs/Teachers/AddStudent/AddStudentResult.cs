using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Errors;
using KinderGartenApp.Core.Shared;

namespace KinderGartenApp.Application.DTOs.Teachers.AddStudent;

/// <summary>
/// DTO para la respuesta de añadir un estudiante a un maestro.
/// </summary>
public record class AddStudentResult
{
    /// <summary>
    /// Identificador único del estudiante añadido.
    /// </summary>
    public Guid StudentId { get; init; }

    /// <summary>
    /// Nombre del estudiante añadido.
    /// </summary>
    public string? StudentFirstName { get; init; }

    /// <summary>
    /// Apellido del estudiante añadido.
    /// </summary>
    public string? StudentLastName { get; init; }

    /// <summary>
    /// Identificador único del maestro al que se añadió el estudiante.
    /// </summary>
    public Guid TeacherId { get; init; }

    /// <summary>
    /// Nombre del maestro.
    /// </summary>
    public string? TeacherFirstName { get; init; }

    /// <summary>
    /// Apellido del maestro.
    /// </summary>
    public string? TeacherLastName { get; init; }

    /// <summary>
    /// Crea una instancia de AddStudentResult usando un Teacher y un Student.
    /// </summary>
    /// <param name="teacher">El objeto Teacher.</param>
    /// <param name="student">El objeto Student de tipo Child.</param>
    /// <returns>Una instancia de AddStudentResult.</returns>
    public static AddStudentResult CreateFrom(Teacher? teacher, Child? student)
    {
        if (teacher is null)
        {
            throw new ArgumentNullException(nameof(teacher), Error.Teacher.IsNull.Message);
        }

        if (student is null)
        {
            throw new ArgumentNullException(nameof(student), Error.Child.IsNull.Message);
        }

        return new AddStudentResult
        {
            StudentId = student.Id,
            StudentFirstName = student.FirstName,
            StudentLastName = student.LastName,
            TeacherId = teacher.Id,
            TeacherFirstName = teacher.FirstName,
            TeacherLastName = teacher.LastName
        };
    }
}
