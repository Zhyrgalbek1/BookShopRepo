using Domain.Entities;
using Domain.Repos;
using MediatR;
using System.Diagnostics;

namespace QueryHandlers.Books.GetAll;

public class GetByTitleHandler : IRequestHandler<GetBookByTitleRequest, BookDto?>
{
    private readonly IBookRepo _bookRepository;

    public GetByTitleHandler(IBookRepo bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<BookDto?> Handle(GetBookByTitleRequest request, CancellationToken cancellationToken)
    {
         var book = await _bookRepository.GetByTitleAsync(request.Title);
        if (book is not null)
        {
            var result = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Count = book.Count,
                Price = book.Price,
            };
            return result;
        }
        throw new Exception("Book is not found");
    }
}
