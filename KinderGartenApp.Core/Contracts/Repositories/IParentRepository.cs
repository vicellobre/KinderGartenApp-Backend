using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Core.Contracts.Repositories;

/// <summary>
/// Define la interfaz para el repositorio de padres, proporcionando métodos para CRUD y consultas específicas.
/// </summary>
public interface IParentRepository
{
    /// <summary>
    /// Obtiene un padre por su identificador de manera asíncrona.
    /// </summary>
    /// <param name="id">El identificador único del padre.</param>
    /// <param name="cancellationToken">Un token de cancelación opcional.</param>
    /// <returns>Una tarea que representa la operación asíncrona. El resultado contiene el padre si se encuentra, de lo contrario, null.</returns>
    Task<Parent?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtiene un padre por su identificador sin realizar seguimiento de cambios, de manera asíncrona.
    /// </summary>
    /// <param name="id">El identificador único del padre.</param>
    /// <param name="cancellationToken">Un token de cancelación opcional.</param>
    /// <returns>Una tarea que representa la operación asíncrona. El resultado contiene el padre si se encuentra, de lo contrario, null.</returns>
    Task<Parent?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtiene un padre por su identificador junto con su padre, sin realizar seguimiento de cambios, de manera asíncrona.
    /// </summary>
    /// <param name="parentId">El identificador único del padre.</param>
    /// <param name="cancellationToken">Un token de cancelación opcional.</param>
    /// <returns>Una tarea que representa la operación asíncrona. El resultado contiene el padre con sus hijos si se encuentra; de lo contrario, null.</returns>
    Task<Parent?> GetByIdWithSonsAsNoTrackingAsync(Guid parentId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtiene todos los padres de manera asíncrona.
    /// </summary>
    /// <param name="cancellationToken">Un token de cancelación opcional.</param>
    /// <returns>Una tarea que representa la operación asíncrona. El resultado contiene una colección de todos los padres.</returns>
    Task<IEnumerable<Parent>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtiene todos los padres por nivel educativo de manera asíncrona.
    /// </summary>
    /// <param name="email">El nivel educativo de los padres a buscar.</param>
    /// <param name="cancellationToken">Un token de cancelación opcional.</param>
    /// <returns>Una tarea que representa la operación asíncrona. El resultado contiene el padre por email si se encuentra, de lo contrario, null.</returns>
    Task<Parent?> GetByEmailAsNoTrackingAsync(string email, CancellationToken cancellationToken = default);

    /// <summary>
    /// Comprueba si un padre con el identificador especificado existe en el repositorio.
    /// </summary>
    /// <param name="id">El identificador único del padre.</param>
    /// <param name="cancellationToken">Un token de cancelación opcional.</param>
    /// <returns>Una tarea que representa la operación asíncrona. El resultado indica si el padre existe en el repositorio.</returns>
    Task<bool> ContainsAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Agrega un nuevo padre al repositorio.
    /// </summary>
    /// <param name="parent">El padre a agregar.</param>
    void Add(Parent parent);

    /// <summary>
    /// Actualiza un padre existente en el repositorio.
    /// </summary>
    /// <param name="parent">El padre a actualizar.</param>
    void Update(Parent parent);

    /// <summary>
    /// Elimina un padre del repositorio.
    /// </summary>
    /// <param name="parent">El padre a eliminar.</param>
    void Delete(Parent parent);
}
