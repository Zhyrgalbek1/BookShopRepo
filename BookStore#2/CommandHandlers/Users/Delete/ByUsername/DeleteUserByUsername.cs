using MediatR;

namespace CommandHandlers.Users.Delete.ByTitle;

public record DeleteUserByUsername : IRequest<bool>
{
    public required string Username { get; init; }
}

