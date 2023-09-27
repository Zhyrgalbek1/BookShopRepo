using Domain.Entities;
using Domain.Enums;
using Domain.Repos;
using Infrastructure.Shared;
using MediatR;


namespace Application.Users.Commands
{
    public record CreateUserResponse
    {
        public long Id { get; init; }
        public required string Username { get; init; }
        public required UserRole Role { get; init; }
    }
    public record CreateUserCommand : IRequest<CreateUserResponse>
    {
        public required string Username { get; init; }
        public required string Password { get; init; }
        public required UserRole Role { get; init; }
    }

    internal class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepo _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserHandler(IUserRepo userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
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

            var response = new CreateUserResponse
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role,
            };
            return response;
        }
    }
}
