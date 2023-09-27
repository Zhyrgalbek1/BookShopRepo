using Domain.Entities;
using Domain.Repos;
using MediatR;
using System.Diagnostics;

namespace QueryHandlers.Books.GetAll;

internal class GetAllHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
{
    private readonly IBookRepo _bookRepository;

    public GetAllHandler(IBookRepo bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetAllAsync(cancellationToken);
        var bookList = new List<BookDto>();
        foreach (var book in books)
        {
            var bookResult = new BookDto()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Count = book.Count,
                Price = book.Price,
            };
            bookList.Add(bookResult);         
        }
        return bookList;
    }
}
