using Domain.Repos;
using MediatR;
using QueryHandlers.Baskets;

namespace Infrastructure.Baskets.Requests;



internal class GetBooksFromBasketHandler : IRequestHandler<GetBooksFromBasketCommand, GetBooksFromBasketResponse?>
{
    private readonly IUserRepo _userRepository;

    public GetBooksFromBasketHandler(IUserRepo userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetBooksFromBasketResponse?> Handle(GetBooksFromBasketCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username, cancellationToken);

        if (user is not null)
        {
            var response = new GetBooksFromBasketResponse();
            response.Books.AddRange(user.Basket.Books);
            return response;
        }
        return default;
    }
}
