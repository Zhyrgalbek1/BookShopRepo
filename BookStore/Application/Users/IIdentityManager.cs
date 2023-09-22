using Application.Users.Dtos;

namespace Application.Users;

public interface IIdentityManager
{
    Task CreateAsync(UserDto user, string password);
    Task<bool> ExistsAsync(string email);
    Task<UserDto?> GetByEmailAsync(string email);
}
