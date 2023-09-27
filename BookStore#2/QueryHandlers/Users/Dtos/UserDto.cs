using Domain.Enums;

namespace Application.Users.Dtos
{
    public record UserDto
    {
        public long Id { get; init; }
        public required string Username { get; init; }
        public required UserRole Role { get; init; }
    }

}
