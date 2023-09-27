using Domain.Entities;
using Domain.Shared;
using System.Collections.Generic;

namespace Domain.Repos;

public interface IUserRepo : IRepository<User>
{
    Task<string> HashAsync(string password);
    Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
    Task<bool> DeleteByUsesrnameAsync(string username);
    Task<IEnumerable<User>> GetSomeUsersByNames(string[] names);
    Task<User?> CheckUserCredentials(string username, string password);
}
