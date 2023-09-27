using Domain.Repos;
using MediatR;

namespace QueryHandlers.Users.Get.GetAll;

internal class GetByUsernameHandler : IRequestHandler<GetAllUsersRequest, IEnumerable<GetUsersResponse>>
{
    private readonly IUserRepo _userRepository;

    public GetByUsernameHandler(IUserRepo userRepository)
    {
        _userRepository = userRepository;
    }
    6
    public async Task<IEnumerable<GetUsersResponse>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);
        var response = new List<GetUsersResponse>();
        foreach (var user in users)
        {
            var result = new GetUsersResponse
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role,
                DateOfBirth = user.Profile.DateOfBirth,
                FirstName = user.Profile.FirstName,
                LastName = user.Profile.LastName,
                Email = user.Profile.Email,

            };
            response.Add(result);
        }
        return response;
    }
}
