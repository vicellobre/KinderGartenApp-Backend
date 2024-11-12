using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Primitives;

namespace KinderGartenApp.Core.Entities;

/// <summary>
/// Clase que representa a un maestro en el sistema.
/// Hereda de la entidad base <see cref="Entity"/> e incluye propiedades específicas del maestro.
/// </summary>
public class Teacher : Entity
{
    /// <summary>
    /// Constructor privado para inicializar una nueva instancia de la clase <see cref="Teacher"/> 
    /// con los valores especificados.
    /// </summary>
    /// <param name="id">Identificador único del maestro.</param>
    /// <param name="firstName">Nombre del maestro.</param>
    /// <param name="lastName">Apellido del maestro.</param>
    /// <param name="gradeLevel">Nivel educativo o grado asignado al maestro.</param>
    private Teacher(Guid id, string? firstName, string? lastName, GradeLevel gradeLevel) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        GradeLevel = gradeLevel;
        Students = [];
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
    /// Obtiene o establece la colección de niños asignados al maestro.
    /// </summary>
    public ICollection<Child> Students { get; set; }

    /// <summary>
    /// Crea una nueva instancia de la clase <see cref="Teacher"/> con los valores especificados.
    /// </summary>
    /// <param name="id">Identificador único del maestro.</param>
    /// <param name="firstName">Nombre del maestro.</param>
    /// <param name="lastName">Apellido del maestro.</param>
    /// <param name="gradeLevel">Nivel educativo o grado asignado al maestro.</param>
    /// <returns>Una nueva instancia de la clase <see cref="Teacher"/>.</returns>
    public static Teacher Create(Guid id, string? firstName, string? lastName, GradeLevel gradeLevel) => new(id, firstName, lastName, gradeLevel);
}
