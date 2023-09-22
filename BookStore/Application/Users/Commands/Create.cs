using Application.Users.Dtos;
using MediatR;

namespace Application.Users.Command;

public record CreateUserCommand
    : IRequest<UserDto>
{
    public required string Email { get; init; }
    public required string Password { get; set; }
    public List<string> Roles { get; set; } = new();
}

public class User
{
    public required string Email { get; init; }
    public required string Password { get; set; }
}

internal class CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IIdentityManager _identityManager;

    public CreateUserCommandHandler(IIdentityManager identity)
    {
        _identityManager = identity;
    }

    public async Task<UserDto> Handle(
        CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new UserDto
        {
            Email = request.Email,
            Roles = request.Roles,
        };

        await _identityManager.CreateAsync(user, request.Password);

        return user;
    }
}



