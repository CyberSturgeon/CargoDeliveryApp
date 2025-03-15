using CargoDeliveryWeb.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace CargoDeliveryWeb.Data.Repositories;

public class BaseRepository<TEntity>(AppDbContext Context) : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DbSet<TEntity> _dbSet = Context.Set<TEntity>();
    public virtual async Task<TEntity?> GetByIdAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> query = _dbSet;

        if (include != null)
        {
            query = include(query);
        }

        return await query.SingleOrDefaultAsync(predicate);
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await Context.SaveChangesAsync();
    }

    public virtual async Task RemoveAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        await Context.SaveChangesAsync();
    }
}
