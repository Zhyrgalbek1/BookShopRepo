using Infrastructure.Shared;
using CommandHandlers.Usesrs.Update;
using Domain.Repos;
using MediatR;
using Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CommandHandlers.Users.Update;

internal class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUser?>
{
    private readonly IUserRepo _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserHandler(IUserRepo userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateUser?> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username, cancellationToken);
        if (user is not null)
        {
            user.Username ??= request.Username;
            user.PasswordHash ??= request.Password;
            user.Role = request.Role;
            user.Profile = new UserProfile
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
            };

            _userRepository.Update(user);
            await _unitOfWork.CommitAsync();

            var response = new UpdateUser
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
            };
            return response;
        }
        return default;
    }

}