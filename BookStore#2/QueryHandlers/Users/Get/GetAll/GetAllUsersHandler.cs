using Domain.Entities;
using Domain.Repos;
using MediatR;

namespace QueryHandlers.Users.Get.GetAll;

internal class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, IEnumerable<GetUsersResponse>>
{
    private readonly IUserRepo _userRepository;

    public GetAllUsersHandler(IUserRepo userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<IEnumerable<GetUsersResponse>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);
        var response = users.Select(u =>
            new GetUsersResponse
            {
                Id = u.Id,
                Username = u.Username,
                Role = u.Role,
                FirstName = u.Profile.FirstName,
                LastName = u.Profile.LastName,
                Email = u.Profile.Email,
            });

        return response;
    }
}
