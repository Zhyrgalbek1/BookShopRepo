using Domain.Entities;

namespace Domain.Repositories
{
    public interface IOrderRepository
    {
        void Update(Order order);
        Task<bool> Delete(long id);
        Task<IEnumerable<Order>> GetAll();
        Task<Order?> GetById(long id);
        Task Create(Order order);
    }

}
