using Infrastructure.Shared;
using Domain.Entities;
using Domain.Repos;
using MediatR;

namespace CommandHandlers.Users.Create;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUser>
{
    private readonly IUserRepo _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserHandler(IUserRepo userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateUser> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Username = request.Username,
            PasswordHash = request.Password,
            Role = request.Role,
            Basket = new(),
        };

        await _userRepository.CreateAsync(user);
        await _unitOfWork.CommitAsync();

        var result = new CreateUser
        {
            Id = user.Id,
            Username = user.Username,
            Role = user.Role,
        };
        return result;
    }
}