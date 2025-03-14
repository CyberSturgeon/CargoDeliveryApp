namespace CargoDeliveryWeb.Data.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(object id);
        Task RemoveAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}