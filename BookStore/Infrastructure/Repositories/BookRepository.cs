using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class BookRepository : IGuardRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Guard entity)
        {
            entity.Id = 0;
            await _context.Guards.AddAsync(entity);
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Guard>> GetAllAsync()
        {
            return _context.Guards.AsNoTracking().ToListAsync();
        }

        public async Task<Guard?> GetByIdAsync(long id)
        {
            var guard = await _context.Guards.FindAsync(id);
            return guard;
        }

        public void Update(Guard entity)
        {
            throw new NotImplementedException();
        }
    }
}
