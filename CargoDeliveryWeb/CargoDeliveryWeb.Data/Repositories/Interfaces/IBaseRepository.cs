using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace CargoDeliveryWeb.Data.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(object id);
        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
        Task RemoveAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}