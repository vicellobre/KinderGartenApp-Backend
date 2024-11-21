using KinderGartenApp.Core.Contracts.Repositories;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Persistence.Abstracts;
using KinderGartenApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Persistence.Repositories;

public class ParentRepository : RepositoryBase<Parent>, IParentRepository
{
    public ParentRepository(KinderGartenContext context) : base(context) { }

    public void Add(Parent parent)
    {
        Set.Add(parent);
    }

    public void Delete(Parent parent)
    {
        Set.Remove(parent);
    }

    public async Task<bool> Contains(Guid id, CancellationToken cancellationToken = default)
    {
        return await Set.AnyAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Parent>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await Set.ToListAsync(cancellationToken);
    }

    public async Task<Parent?> GetByEmailAsNoTrackingAsync(string email, CancellationToken cancellationToken = default)
    {
        return await Set
            .AsNoTracking()
            .FirstOrDefaultAsync(parent => parent.Email == email, cancellationToken);
    }

    public async Task<Parent?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Set
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<Parent?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Set.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    public async Task<Parent?> GetByIdWithSonsAsNoTrackingAsync(Guid parentId, CancellationToken cancellationToken = default)
    {
        return await Set
            .AsNoTracking()
            .Include(x => x.Sons)
            .FirstOrDefaultAsync(p => p.Id == parentId, cancellationToken: cancellationToken);
    }

    public void Update(Parent parent)
    {
        Set.Update(parent);
    }
}
