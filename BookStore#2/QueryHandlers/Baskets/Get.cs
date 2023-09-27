using Domain.Entities;
using MediatR;

namespace QueryHandlers.Baskets;

public record GetBooksFromBasketResponse
{
    public List<Book> Books { get; init; } = new();
}

public record GetBooksFromBasketCommand : IRequest<GetBooksFromBasketResponse?>
{
    public required string Username { get; init; }
}
