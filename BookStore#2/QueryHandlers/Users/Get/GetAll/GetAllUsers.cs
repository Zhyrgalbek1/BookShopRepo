using Domain.Entities;
using Domain.Enums;
using MediatR;
using System.Data;

namespace QueryHandlers.Users.Get.GetAll;

public record GetUsersResponse
{
    public long Id { get; init; }
    public required string Username { get; init; }
    public required UserRole Role { get; init; }
}
public record GetAllUsersRequest : IRequest<IEnumerable<GetUsersResponse>> { }
