using Infrastructure.Shared;
using Domain.Repos;
using MediatR;

namespace Infrastructure.Baskets.Commands;

public record AddBookToBasketCommand : IRequest<bool>
{
    public required string Title { get; init; }
    public required string Username { get; init; }
}
