using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Primitives;

namespace KinderGartenApp.Core.Entities;

/// <summary>
/// Clase que representa a un maestro en el sistema.
/// Hereda de la entidad base e incluye propiedades específicas del maestro.
/// </summary>
public class Teacher : Entity
{
    private Teacher(Guid id, string? firstName, string? lastName, GradeLevel gradeLevel) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        GradeLevel = gradeLevel;
    }

    /// <summary>
    /// Nombre del maestro.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Apellido del maestro.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Nivel educativo o grado asignado al maestro, indicando el grupo de estudiantes a los que enseña.
    /// </summary>
    public GradeLevel GradeLevel { get; set; }

    /// <summary>
    /// Colección de estudiantes (niños) asignados al maestro.
    /// </summary>
    //public ICollection<Children> Students { get; set; }

    public static Teacher Create(Guid id, string? firstName, string? lastName, GradeLevel gradeLevel)
    {
        // Validación para asegurar que el gradeLevel es un valor válido del enum
        if (!Enum.IsDefined(typeof(GradeLevel), gradeLevel))
        {
            throw new ArgumentException("Invalid grade level", nameof(gradeLevel));
        }

        return new(id, firstName, lastName, gradeLevel);
    }
}