using MediatR;

namespace CommandHandlers.Books.Delete.ById;

public class DeleteBookById : IRequest<bool>
{   
   public required long Id { get; init; }
}
