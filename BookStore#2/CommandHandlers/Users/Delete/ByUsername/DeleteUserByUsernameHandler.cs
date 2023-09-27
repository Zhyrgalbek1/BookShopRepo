using Infrastructure.Shared;
using Domain.Repos;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandHandlers.Users.Delete.ByTitle;
internal class DeleteUserByNameHandler : IRequestHandler<DeleteUserByUsername, bool>
{
    private readonly IUserRepo _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserByNameHandler(IUserRepo userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteUserByUsername request, CancellationToken cancellationToken)
    {
        var response = await _userRepository.DeleteByUsesrnameAsync(request.Username);
        if (response == true)
            await _unitOfWork.CommitAsync();
        return response;
    }
}