using Domain.Enums;
using MediatR;
using System.Data;

namespace CommandHandlers.Users.Create;

public record CreateUserCommand : IRequest<CreateUser>
{
    public required string Username { get; init; }
    public required string Password { get; init; }
    public UserRole Role { get; init; }

}

public record CreateUser
{
    public long Id { get; init; }
    public required string Username { get; init; }
    public required UserRole Role { get; init; }
}

