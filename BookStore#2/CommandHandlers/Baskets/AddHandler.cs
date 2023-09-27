using Infrastructure.Baskets.Commands;
using Infrastructure.Shared;
using Domain.Repos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandHandlers.Baskets;

internal class AddBookToBasketHandler : IRequestHandler<AddBookToBasketCommand, bool>
{
    private readonly IUserRepo _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBookRepo _bookRepository;

    public AddBookToBasketHandler(IUserRepo userRepository, IUnitOfWork unitOfWork, IBookRepo bookRepository)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _bookRepository = bookRepository;
    }

    public async Task<bool> Handle(AddBookToBasketCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username, cancellationToken);
        var book = await _bookRepository.GetByTitleAsync(request.Title);

        if (user is not null && book is not null)
        {
            user.Basket.Books.Add(book);
            await _unitOfWork.CommitAsync();
            return true;
        }
        return false;
    }
}