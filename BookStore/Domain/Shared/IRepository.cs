namespace Domain.Shared;

public interface IRepository<TEntity>
{
    Task<TEntity?> GetByIdAsync(long id);
    Task<List<TEntity>> GetAllAsync();
    Task CreateAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(long id);
}
