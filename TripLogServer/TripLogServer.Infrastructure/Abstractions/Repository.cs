using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TripLogServer.Domain.Abstractions;

namespace TripLogServer.Infrastructure.Abstractions;

public class Repository<TEntity, Tcontext> : IRepository<TEntity> where TEntity : class where Tcontext : DbContext
{
    private readonly Tcontext _context;

    private DbSet<TEntity> Entity;

    public IQueryable<TEntity> where(Expression<Func<TEntity, bool>> expression)
    {
        return _context.Set<TEntity>().Where(expression).AsQueryable();
    }

    public bool Any(Expression<Func<TEntity, bool>> expression)
    {
       return  _context.Set<TEntity>().Any(expression);
    }

    public Repository(Tcontext context)
    {
        _context = context;
        Entity = _context.Set<TEntity>();
    }

    public async Task CreateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _context.AddAsync(entity,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
    {
         _context.Remove(entity);
       await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
       return await _context.Set<TEntity>().ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
       return await _context.Set<TEntity>().FindAsync(id);
     

    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
         _context.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
   


