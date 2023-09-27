using Domain.Enums;
using MediatR;

namespace CommandHandlers.Usesrs.Update;

public record UpdateUser
{
    public long Id { get; init; }
    public required string Username { get; init; }
    public required UserRole Role { get; init; }

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
}
public record UpdateUserCommand : IRequest<UpdateUser?>
{
    public required string Username { get; init; }
    public required string Password { get; init; }
    public UserRole Role { get; init; }

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
}
