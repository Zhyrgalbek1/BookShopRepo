using Infrastructure.Shared;
using CommandHandlers.Usesrs.Update;
using Domain.Repos;
using MediatR;

namespace CommandHandlers.Users.Update;

internal class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse?>
{
    private readonly IUserRepo _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserHandler(IUserRepo userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateUserResponse?> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username, cancellationToken);
        if (user is not null)
        {
            user.Username ??= request.Username;
            user.PasswordHash ??= request.Password;
            user.Role = request.Role;

            _userRepository.Update(user);
            await _unitOfWork.CommitAsync();

            var response = new UpdateUserResponse
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role,
            };
            return response;
        }
        return default;
    }

}

