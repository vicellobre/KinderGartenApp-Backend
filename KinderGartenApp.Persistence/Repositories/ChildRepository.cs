using KinderGartenApp.Core.Contracts.Repositories;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Persistence.Abstracts;
using KinderGartenApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Persistence.Repositories;

internal class ChildRepository : RepositoryBase<Child>, IChildRepository
{
    public ChildRepository(KinderGartenContext context) : base(context) { }

    public void Add(Child child)
    {
        Set.Add(child);
    }

    public void Delete(Child child)
    {
        Set.Remove(child);
    }

    public async Task<bool> Contains(Guid id, CancellationToken cancellationToken = default)
    {
        return await Set.AnyAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Child>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await Set.ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Child>> GetAllByGradeLevel(GradeLevel gradeLevel, CancellationToken cancellationToken = default)
    {
        return await Set
            .Where(x => x.GradeLevel == gradeLevel)
            .ToListAsync(cancellationToken);
    }

    public async Task<Child?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Set
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task<Child?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Set.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    public async Task<Child?> GetByIdWithParentAsNoTrackingAsync(Guid childId, CancellationToken cancellationToken = default)
    {
        return await Set
            .AsNoTracking()
            .Include(x => x.Parent)
            .FirstOrDefaultAsync(t => t.Id == childId, cancellationToken: cancellationToken);
    }

    public void Update(Child child)
    {
        Set.Update(child);
    }
}
