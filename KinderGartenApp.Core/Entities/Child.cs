using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Core.Primitives;

namespace KinderGartenApp.Core.Entities;

/// <summary>
/// Representa un niño con propiedades de nombre, fecha de nacimiento, nivel educativo, 
/// y referencias a su padre/madre.
/// </summary>
public class Child : Entity
{
    /// <summary>
    /// Obtiene o establece el primer nombre del niño.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Obtiene o establece el apellido del niño.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Obtiene o establece la fecha de nacimiento del niño.
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Obtiene o establece el nivel educativo del niño.
    /// </summary>
    public GradeLevel GradeLevel { get; set; }

    /// <summary>
    /// Obtiene o establece el identificador del padre/madre.
    /// </summary>
    public int ParentId { get; set; }

    /// <summary>
    /// Obtiene o establece una referencia al padre/madre del niño.
    /// </summary>
    public Parent? Parent { get; set; }

    /// <summary>
    /// Constructor privado para inicializar una nueva instancia de la clase <see cref="Child"/> 
    /// con los valores especificados.
    /// </summary>
    /// <param name="id">Identificador único del niño.</param>
    /// <param name="firstName">Primer nombre del niño.</param>
    /// <param name="lastName">Apellido del niño.</param>
    /// <param name="birthDate">Fecha de nacimiento del niño.</param>
    /// <param name="gradeLevel">Nivel educativo del niño.</param>
    /// <param name="parentId">Identificador del padre/madre del niño.</param>
    private Child(Guid id, string? firstName, string? lastName, DateTime birthDate, GradeLevel gradeLevel, int parentId) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        GradeLevel = gradeLevel;
        ParentId = parentId;
    }

    /// <summary>
    /// Crea una nueva instancia de la clase <see cref="Child"/> con los valores especificados.
    /// </summary>
    /// <param name="id">Identificador único del niño.</param>
    /// <param name="firstName">Primer nombre del niño.</param>
    /// <param name="lastName">Apellido del niño.</param>
    /// <param name="birthDate">Fecha de nacimiento del niño.</param>
    /// <param name="gradeLevel">Nivel educativo del niño.</param>
    /// <param name="parentId">Identificador del padre/madre del niño.</param>
    /// <returns>Una nueva instancia de la clase <see cref="Child"/>.</returns>
    public static Child Create(Guid id, string? firstName, string? lastName, DateTime birthDate, GradeLevel gradeLevel, int parentId)
    {
        return new(id, firstName, lastName, birthDate, gradeLevel, parentId);
    }

    /// <summary>
    /// Establece el padre/madre del niño.
    /// </summary>
    /// <param name="parent">El padre/madre a asignar.</param>
    /// <returns>Devuelve <c>true</c> si el padre/madre se asignó correctamente; de lo contrario, <c>false</c>.</returns>
    public bool SetParent(Parent parent)
    {
        if (parent is null)
        {
            return false;
        }

        Parent = parent;
        return true;
    }
}
