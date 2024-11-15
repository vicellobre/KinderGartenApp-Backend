using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Core.Contracts.Repositories;

/// <summary>
/// Define la interfaz para el repositorio de maestros, proporcionando métodos para CRUD y consultas específicas.
/// </summary>
public interface ITeacherRepository
{
    /// <summary>
    /// Obtiene un maestro por su identificador de manera asíncrona.
    /// </summary>
    /// <param name="id">El identificador único del maestro.</param>
    /// <param name="cancellationToken">Un token de cancelación opcional.</param>
    /// <returns>Una tarea que representa la operación asíncrona. El resultado contiene el maestro si se encuentra, de lo contrario, null.</returns>
    Task<Teacher?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtiene un maestro por su identificador sin realizar seguimiento de cambios, de manera asíncrona.
    /// </summary>
    /// <param name="id">El identificador único del maestro.</param>
    /// <param name="cancellationToken">Un token de cancelación opcional.</param>
    /// <returns>Una tarea que representa la operación asíncrona. El resultado contiene el maestro si se encuentra, de lo contrario, null.</returns>
    Task<Teacher?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtiene un maestro por su identificador junto con sus estudiantes, sin realizar seguimiento de cambios, de manera asíncrona.
    /// </summary>
    /// <param name="teacherId">El identificador único del maestro.</param>
    /// <param name="cancellationToken">Un token de cancelación opcional.</param>
    /// <returns>Una tarea que representa la operación asíncrona. El resultado contiene el maestro con sus estudiantes si se encuentra; de lo contrario, null.</returns>
    Task<Teacher?> GetByIdWithStudentsAsNoTrackingAsync(Guid teacherId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtiene todos los maestros de manera asíncrona.
    /// </summary>
    /// <param name="cancellationToken">Un token de cancelación opcional.</param>
    /// <returns>Una tarea que representa la operación asíncrona. El resultado contiene una colección de todos los maestros.</returns>
    Task<IEnumerable<Teacher>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtiene todos los maestros por nivel educativo de manera asíncrona.
    /// </summary>
    /// <param name="gradeLevel">El nivel educativo de los maestros a buscar.</param>
    /// <param name="cancellationToken">Un token de cancelación opcional.</param>
    /// <returns>Una tarea que representa la operación asíncrona. El resultado contiene una colección de maestros filtrados por nivel educativo.</returns>
    Task<IEnumerable<Teacher>> GetAllByGradeLevel(GradeLevel gradeLevel, CancellationToken cancellationToken = default);

    /// <summary>
    /// Comprueba si un maestro con el identificador especificado existe en el repositorio.
    /// </summary>
    /// <param name="id">El identificador único del maestro.</param>
    /// <param name="cancellationToken">Un token de cancelación opcional.</param>
    /// <returns>Una tarea que representa la operación asíncrona. El resultado indica si el maestro existe en el repositorio.</returns>
    Task<bool> Contains(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Agrega un nuevo maestro al repositorio.
    /// </summary>
    /// <param name="teacher">El maestro a agregar.</param>
    void Add(Teacher teacher);

    /// <summary>
    /// Actualiza un maestro existente en el repositorio.
    /// </summary>
    /// <param name="teacher">El maestro a actualizar.</param>
    void Update(Teacher teacher);

    /// <summary>
    /// Elimina un maestro del repositorio.
    /// </summary>
    /// <param name="teacher">El maestro a eliminar.</param>
    void Delete(Teacher teacher);
}
