using Domain.Enums;
using MediatR;

namespace CommandHandlers.Usesrs.Update;

public record UpdateUserResponse
{
    public long Id { get; init; }
    public required string Username { get; init; }
    public required UserRole Role { get; init; }
}
public record UpdateUserCommand : IRequest<UpdateUserResponse?>
{
    public required string Username { get; init; }
    public required string Password { get; init; }
    public required UserRole Role { get; init; }
}
