namespace Application.Users.Dtos;

public class UserDto
{
    public required string Email { get; set; }
    public List<string> Roles { get; set; } = new();
}
