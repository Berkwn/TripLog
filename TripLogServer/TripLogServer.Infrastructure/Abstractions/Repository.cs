using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLogServer.Domain.Abstractions;
using TripLogServer.Infrastructure.Context;

namespace TripLogServer.Infrastructure.Abstractions;

public class Repository<TEntity, Tcontext> : IRepository<TEntity> where TEntity : class where Tcontext : DbContext
{
    private readonly Tcontext _context;

    private DbSet<TEntity> Entity;

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
   


