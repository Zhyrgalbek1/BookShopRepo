using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Repositories
{
    public class OrderRepo : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(Order order)
        {
            await _appDbContext.Orders.AddAsync(order);
        }

        public async Task<bool> Delete(long id)
        {
            var order = await _appDbContext.Orders.FindAsync(id);
            if (order != null)
            {
                _appDbContext.Orders.Remove(order);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _appDbContext.Orders.AsNoTracking().ToListAsync();
        }

        public async Task<Order?> GetById(long id)
        {
            var order = await _appDbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
            return order;
        }

        public void Update(Order order)
        {
            _appDbContext.Orders.Update(order);
        }
    }

}
