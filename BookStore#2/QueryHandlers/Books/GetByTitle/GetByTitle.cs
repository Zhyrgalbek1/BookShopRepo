using Domain.Entities;
using MediatR;

namespace QueryHandlers.Books.GetAll;
public record GetBookByTitleRequest : IRequest<BookDto> 
{ 
    public required string Title { get; init; } 
}


