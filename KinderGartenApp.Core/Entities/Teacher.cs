using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Primitives;

namespace KinderGartenApp.Core.Entities;

/// <summary>
/// Clase que representa a un maestro en el sistema.
/// Hereda de la entidad base e incluye propiedades específicas del maestro.
/// </summary>
public class Teacher : Entity
{
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
}