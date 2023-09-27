using Domain.Enums;

namespace Domain.Entities;

public class User
{
    public long Id { get; set; }
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public UserRole Role { get; set; }
    public Basket Basket { get; set; } = new();
}
