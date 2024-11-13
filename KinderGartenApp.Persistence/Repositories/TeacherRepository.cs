using KinderGartenApp.Core.Contracts.Repositories;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Persistence.Abstracts;
using KinderGartenApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace KinderGartenApp.Persistence.Repositories;

/// <summary>
/// Implementa el repositorio de maestros, proporcionando métodos para CRUD y consultas específicas.
/// </summary>
[ExcludeFromCodeCoverage]
public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="TeacherRepository"/>.
    /// </summary>
    /// <param name="context">El contexto de base de datos utilizado para gestionar el conjunto de entidades.</param>
    public TeacherRepository(KinderGartenContext context) : base(context) { }

    /// <summary>
    /// Obtiene un maestro por su identificador de manera asíncrona.
    /// </summary>
    /// <param name="id">El identificador único del maestro.</param>
    /// <param name="cancellationToken">Un token de cancelación opcional.</param>
    /// <returns>Una tarea que representa la operación asíncrona. El resultado contiene el maestro si se encuentra, de lo contrario, null.</returns>
    public async Task<Teacher?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Set.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    /// <summary>
    /// Obtiene un maestro por su identificador sin realizar seguimiento de cambios, de manera asíncrona.
    /// </summary>
    /// <param name="id">El identificador único del maestro.</param>
    /// <param name="cancellationToken">Un token de cancelación opcional.</param>
    /// <returns>Una tarea que representa la operación asíncrona. El resultado contiene el maestro si se encuentra, de lo contrario, null.</returns>
    public async Task<Teacher?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Set.AsNoTracking().FirstOrDefaultAsync(teacher => teacher.Id == id, cancellationToken);
    }

    /// <summary>
    /// Obtiene todos los maestros de manera asíncrona.
    /// </summary>
    /// <param name="cancellationToken">Un token de cancelación opcional.</param>
    /// <returns>Una tarea que representa la operación asíncrona. El resultado contiene una colección de todos los maestros.</returns>
    public async Task<IEnumerable<Teacher>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await Set.ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Comprueba si un maestro con el identificador especificado existe en el repositorio.
    /// </summary>
    /// <param name="id">El identificador único del maestro.</param>
    /// <param name="cancellationToken">Un token de cancelación opcional.</param>
    /// <returns>Una tarea que representa la operación asíncrona. El resultado indica si el maestro existe en el repositorio.</returns>
    public async Task<bool> Contains(Guid id, CancellationToken cancellationToken = default)
    {
        return await Set.AnyAsync(t => t.Id == id, cancellationToken);
    }

    /// <summary>
    /// Obtiene todos los maestros por nivel educativo de manera asíncrona.
    /// </summary>
    /// <param name="gradeLevel">El nivel educativo de los maestros a buscar.</param>
    /// <param name="cancellationToken">Un token de cancelación opcional.</param>
    /// <returns>Una tarea que representa la operación asíncrona. El resultado contiene una colección de maestros filtrados por nivel educativo.</returns>
    public async Task<IEnumerable<Teacher>> GetAllByGradeLevel(GradeLevel gradeLevel, CancellationToken cancellationToken = default)
    {
        return await Set.Where(t => t.GradeLevel == gradeLevel).ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Agrega un nuevo maestro al repositorio.
    /// </summary>
    /// <param name="teacher">El maestro a agregar.</param>
    public void Add(Teacher teacher)
    {
        Set.Add(teacher);
    }

    /// <summary>
    /// Actualiza un maestro existente en el repositorio.
    /// </summary>
    /// <param name="teacher">El maestro a actualizar.</param>
    public void Update(Teacher teacher)
    {
        Set.Update(teacher);
    }

    /// <summary>
    /// Elimina un maestro del repositorio.
    /// </summary>
    /// <param name="teacher">El maestro a eliminar.</param>
    public void Delete(Teacher teacher)
    {
        Set.Remove(teacher);
    }
}
