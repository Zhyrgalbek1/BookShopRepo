using MediatR;

namespace CommandHandlers.Books.Create;

public record CreateBook : IRequest<CreateBookResponse>
{
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required int Count { get; set; }
    public required decimal Price { get; set; }
}


public record CreateBookResponse
{
    public long Id { get; init; }
    public required string Title { get; init; }
    public string? Description { get; init; }
    public required int Count { get; init; }
    public required decimal Price { get; init; }
}