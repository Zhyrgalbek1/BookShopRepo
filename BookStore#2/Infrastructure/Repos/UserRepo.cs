using Domain.Entities;
using Domain.Repos;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Repositories;

public class UserRepo : IUserRepo
{
    private readonly AppDbContext _appDbContext;

    public UserRepo(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task CreateAsync(User user)
    {
        var hashPass = await HashAsync(user.PasswordHash);
        user.PasswordHash = hashPass;
        await _appDbContext.Users.AddAsync(user);
    }

    public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _appDbContext.Users.AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
    }
    public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken)
    {
        var user = await _appDbContext.Users.SingleOrDefaultAsync(u => u.Username == username, cancellationToken: cancellationToken);
        return user ?? null;
    }

    public async Task<string> HashAsync(string password)
    {
        var hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        return await Task.FromResult(hash);
    }

    public async Task<bool> DeleteByIdAsync(long id, CancellationToken cancellationToken)
    {
        var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user is not null)
        {
            _appDbContext.Users.Remove(user);
            return true;
        }
        return false;
    }

    public void Update(User entity)
    {
        _appDbContext.Users.Update(entity);
    }

    public async Task<bool> DeleteByUsesrnameAsync(string username)
    {
        var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        if(user is not null)
        {
            _appDbContext.Users.Remove(user);
            return true;
        }
        return false;
    }

    public async Task<IEnumerable<User>> GetSomeUsersByNames(string[] names)
    {
        var users = await _appDbContext.Users.Where(u => names.Contains(u.Username)).ToListAsync().ConfigureAwait(false);
        return users;
    }

    public async Task<User?> CheckUserCredentials(string username, string password)
    {
        var user = await _appDbContext.Users.SingleOrDefaultAsync(u => u.Username == username).ConfigureAwait(false);
        if (user is null || await HashAsync(password).ConfigureAwait(false) != user.PasswordHash)
            return null;
        return user;
    }
}

