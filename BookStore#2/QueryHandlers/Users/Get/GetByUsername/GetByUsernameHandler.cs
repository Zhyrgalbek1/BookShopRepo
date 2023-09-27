using Domain.Repos;
using MediatR;

namespace QueryHandlers.Users.Get.GetAll;

internal class GetUserByNameHandler : IRequestHandler<GetUserByNameCommand, GetUserResponse?>
{
    private readonly IUserRepo _userRepository;

    public GetUserByNameHandler(IUserRepo userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserResponse?> Handle(GetUserByNameCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUsernameAsync(command.Username, cancellationToken);
        if (user is not null)
        {
            var response = new GetUserResponse
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role,
                Basket = user.Basket,
            };
            return response;
        }
        return default;
    }

}
