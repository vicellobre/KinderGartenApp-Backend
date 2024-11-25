using KinderGartenApp.Core.Contracts.Repositories;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Persistence.Abstracts;
using KinderGartenApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Persistence.Repositories;

/// <summary>
/// Implementa el repositorio de maestros, proporcionando métodos para CRUD y consultas específicas.
/// </summary>
public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
{
    /// <inheritdoc />
    public TeacherRepository(KinderGartenContext context) : base(context) { }

    /// <inheritdoc />
    public async Task<Teacher?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await Set.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

    /// <inheritdoc />
    public async Task<Teacher?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken = default) =>
        await Set
            .AsNoTracking()
            .FirstOrDefaultAsync(teacher => teacher.Id == id, cancellationToken);

    /// <inheritdoc />
    public async Task<Teacher?> GetByIdWithStudentsAsNoTrackingAsync(Guid teacherId, CancellationToken cancellationToken = default) =>
        await Set
            .AsNoTracking()
            .Include(t => t.Students)
            .FirstOrDefaultAsync(t => t.Id == teacherId, cancellationToken: cancellationToken);

    /// <inheritdoc />
    public async Task<IEnumerable<Teacher>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await Set.ToListAsync(cancellationToken);

    /// <inheritdoc />
    public async Task<IEnumerable<Teacher>> GetAllByGradeLevel(GradeLevel gradeLevel, CancellationToken cancellationToken = default) =>
        await Set
            .Where(t => t.GradeLevel == gradeLevel)
            .ToListAsync(cancellationToken);

    /// <inheritdoc />
    public async Task<bool> Contains(Guid id, CancellationToken cancellationToken = default) =>
        await Set.AnyAsync(t => t.Id == id, cancellationToken);

    /// <inheritdoc />
    public void Add(Teacher teacher) => Set.Add(teacher);

    /// <inheritdoc />
    public void Update(Teacher teacher) => Set.Update(teacher);

    /// <inheritdoc />
    public void Remove(Teacher teacher) => Set.Remove(teacher);
}
