using Infrastructure.Shared;
using Domain.Repos;
using MediatR;

namespace CommandHandlers.Books.Update;

internal class UpdateUserHandler : IRequestHandler<UpdateBookCommand, UpdateBook?>
{
    private readonly IBookRepo _bookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserHandler(IBookRepo bookRepository, IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateBook?> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByTitleAsync(request.Title).ConfigureAwait(false);
        if (book is not null)
        {
            book.Title = request.Title;
            book.Description = request.Description;
            book.Price = request.Price;

            _bookRepository.Update(book);
            await _unitOfWork.CommitAsync().ConfigureAwait(false);

            var response = new UpdateBook
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Count = book.Count,
                Price = book.Price,
            };
            return response;
        }
        return default;
    }
}
