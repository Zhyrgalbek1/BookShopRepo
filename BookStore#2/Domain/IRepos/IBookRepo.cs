using Domain.Entities;
using Domain.Shared;

namespace Domain.Repos;

public interface IBookRepo : IRepository<Book>
{
       Task<Book?> GetByTitleAsync(string title);
       Task DeleteByTitleAsync(string title);

}
