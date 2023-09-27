using Infrastructure.Shared;
using Domain.Entities;
using Domain.Repos;
using MediatR;

namespace CommandHandlers.Books.Create;

internal class CreateBookHandler : IRequestHandler<CreateBook, CreateBookResponse>
{
    private readonly IBookRepo _bookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBookHandler(IBookRepo bookRepository, IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateBookResponse> Handle(CreateBook request, CancellationToken cancellationToken)
    {
        var book = new Book
        {
            Title = request.Title,
            Description = request.Description,
            Count = request.Count,
            Price = request.Price,
        };

        await _bookRepository.CreateAsync(book);
        await _unitOfWork.CommitAsync();

        var response = new CreateBookResponse
        {
            Id = book.Id,
            Title = book.Title,
            Description = book.Description,
            Count = book.Count,
            Price = book.Price,
        };

        return response;
    }
}