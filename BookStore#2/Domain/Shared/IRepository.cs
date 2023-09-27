using Domain.Entities;

namespace Domain.Shared
{
    public interface IRepository<TEntity>
    {
        Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
        Task CreateAsync(TEntity entity);
        void Update(TEntity entity);
        Task<bool> DeleteByIdAsync(long id, CancellationToken cancellationToken);
    }
}
