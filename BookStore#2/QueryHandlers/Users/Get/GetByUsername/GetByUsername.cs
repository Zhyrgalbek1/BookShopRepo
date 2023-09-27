using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace QueryHandlers.Users.Get.GetAll;

public record GetUserResponse
{
    public long Id { get; set; }
    public required string Username { get; set; }
    public required UserRole Role { get; init; }
    public Basket? Basket { get; set; }
}
public record GetUserByNameCommand : IRequest<GetUserResponse?>
{ 
    public required string Username { get; init; } 
}
