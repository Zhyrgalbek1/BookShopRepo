using MediatR;

namespace CommandHandlers.Books.Update;

public record UpdateBook
{
    public long Id { get; init; }
    public required string Title { get; init; }
    public string? Description { get; init; }
    public required int Count { get; init; }
    public required decimal Price { get; init; }
}

public record UpdateBookCommand : IRequest<UpdateBook?>
{
    public required string Title { get; init; }
    public string? Description { get; init; }
    public required int Count { get; init; }
    public required decimal Price { get; init; }
}
