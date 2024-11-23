using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Core.Contracts.Repositories;

/// <summary>
/// Define la interfaz para el repositorio de niños, proporcionando métodos para CRUD y consultas específicas.
/// </summary>
public interface IChildRepository
{
    /// <summary>
    /// Obtiene un niño por su identificador de manera asíncrona.
    /// </summary>
    /// <param name="id">El identificador único del niño.</param>
    /// <param name="cancellationToken">Un token de cancelación opcional.</param>
    /// <returns>Una tarea que representa la operación asíncrona. El resultado contiene el niño si se encuentra, de lo contrario, null.</returns>
    Task<Child?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtiene un niño por su identificador sin realizar seguimiento de cambios, de manera asíncrona.
    /// </summary>
    /// <param name="id">El identificador único del niño.</param>
    /// <param name="cancellationToken">Un token de cancelación opcional.</param>
    /// <returns>Una tarea que representa la operación asíncrona. El resultado contiene el niño si se encuentra, de lo contrario, null.</returns>
    Task<Child?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtiene un niño por su identificador junto con su padre, sin realizar seguimiento de cambios, de manera asíncrona.
    /// </summary>
    /// <param name="childId">El identificador único del niño.</param>
    /// <param name="cancellationToken">Un token de cancelación opcional.</param>
    /// <returns>Una tarea que representa la operación asíncrona. El resultado contiene el niño con sus estudiantes si se encuentra; de lo contrario, null.</returns>
    Task<Child?> GetByIdWithParentAsNoTrackingAsync(Guid childId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtiene todos los niños de manera asíncrona.
    /// </summary>
    /// <param name="cancellationToken">Un token de cancelación opcional.</param>
    /// <returns>Una tarea que representa la operación asíncrona. El resultado contiene una colección de todos los niños.</returns>
    Task<IEnumerable<Child>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtiene todos los niños por nivel educativo de manera asíncrona.
    /// </summary>
    /// <param name="gradeLevel">El nivel educativo de los niños a buscar.</param>
    /// <param name="cancellationToken">Un token de cancelación opcional.</param>
    /// <returns>Una tarea que representa la operación asíncrona. El resultado contiene una colección de niños filtrados por nivel educativo.</returns>
    Task<IEnumerable<Child>> GetAllByGradeLevel(GradeLevel gradeLevel, CancellationToken cancellationToken = default);

    /// <summary>
    /// Comprueba si un niño con el identificador especificado existe en el repositorio.
    /// </summary>
    /// <param name="id">El identificador único del niño.</param>
    /// <param name="cancellationToken">Un token de cancelación opcional.</param>
    /// <returns>Una tarea que representa la operación asíncrona. El resultado indica si el niño existe en el repositorio.</returns>
    Task<bool> Contains(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Agrega un nuevo niño al repositorio.
    /// </summary>
    /// <param name="child">El niño a agregar.</param>
    void Add(Child child);

    /// <summary>
    /// Actualiza un niño existente en el repositorio.
    /// </summary>
    /// <param name="child">El niño a actualizar.</param>
    void Update(Child child);

    /// <summary>
    /// Elimina un niño del repositorio.
    /// </summary>
    /// <param name="child">El niño a eliminar.</param>
    void Delete(Child child);
}
