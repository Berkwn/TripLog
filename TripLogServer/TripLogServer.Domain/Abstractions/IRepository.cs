using System.Linq.Expressions;

namespace TripLogServer.Domain.Abstractions;

public interface IRepository<TEntity> where TEntity : class
{
    public IQueryable<TEntity> where(Expression<Func<TEntity, bool>> expression);
    public bool Any(Expression<Func<TEntity, bool>> expression);
    public Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task CreateAsync(TEntity entity, CancellationToken cancellationToken);
    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);



}
