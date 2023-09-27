using Infrastructure.Shared;
using Domain.Repos;
using Infrastructure.Data;
using MediatR;

namespace CommandHandlers.Books.Delete.ById;
public class DeleteByIdHandler : IRequestHandler<DeleteBookById, bool>
{
    private readonly IBookRepo _bookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteByIdHandler(IBookRepo bookRepository, IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteBookById request, CancellationToken cancellationToken)
    {

        var response = await _bookRepository.DeleteByIdAsync(request.Id, cancellationToken);
        if (response)
            await _unitOfWork.CommitAsync();
        return response;
    }


}
