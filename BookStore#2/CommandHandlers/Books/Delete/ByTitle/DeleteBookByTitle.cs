using MediatR;

namespace CommandHandlers.Books.Delete.ByTitle;

public class DeleteBookByTitle : IRequest<bool>
{
    public required string Title { get; init; }
}
