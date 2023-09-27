﻿using Infrastructure.Shared;
using Domain.Repos;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandHandlers.Books.Delete.ByTitle;
internal class DeleteBookByUsernameHandler : IRequestHandler<DeleteBookByTitle,bool>
{
    private readonly IBookRepo _bookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBookByUsernameHandler(IBookRepo bookRepository, IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteBookByTitle request, CancellationToken cancellationToken)
    {
       await _bookRepository.DeleteByTitleAsync(request.Title).ConfigureAwait(false);
       await _unitOfWork.CommitAsync();
        return true;
    }
}
