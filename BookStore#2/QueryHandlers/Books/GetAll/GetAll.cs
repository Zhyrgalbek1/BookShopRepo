using Domain.Entities;
using MediatR;

namespace QueryHandlers.Books.GetAll;
public record GetAllBooksQuery : IRequest<IEnumerable<BookDto>> { }


