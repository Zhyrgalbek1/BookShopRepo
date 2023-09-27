using CommandHandlers.Users.Create;
using Domain.Entities;
using Domain.Enums;
using Domain.Repos;
using Infrastructure.Shared;
using MediatR;
namespace Application.Users.Commands
{

    public record CreateUserCommandExample
    {
        public required string Username { get; init; }
        public required string Password { get; init; }
        public required string Role { get; init; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        
    }
    public record CreateUserResponse
    { 
        public long Id { get; init; }
        public required string Username { get; init; }
        public required UserRole Role { get; init; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
    }
    public record CreateUserCommand : IRequest<CreateUserResponse>
    {
        public required string Username { get; init; }
        public required string Password { get; init; }
        public required UserRole Role { get; init; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
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
                Profile = new UserProfile
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                },
            };

            await _userRepository.CreateAsync(user);
            await _unitOfWork.CommitAsync();

            var result = new CreateUserResponse
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role,
                FirstName = user.Profile.FirstName,
                LastName = user.Profile.LastName,
                Email = user.Profile.Email,
            };
            return result;
        }
    }
}
