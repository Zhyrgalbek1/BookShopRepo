using Infrastructure.Shared;
using Domain.Repos;
using MediatR;

namespace CommandHandlers.Users.Delete.ById;
internal class DeleteUserByIdHandler : IRequestHandler<DeleteUserById, bool>
{
    private readonly IUserRepo _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserByIdHandler(IUserRepo userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteUserById request, CancellationToken cancellationToken)
    {
        var response = await _userRepository.DeleteByIdAsync(request.Id, cancellationToken);
        if (response)
            await _unitOfWork.CommitAsync();
        return response;
    }
}
