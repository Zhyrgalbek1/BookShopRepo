using MediatR;

namespace CommandHandlers.Users.Delete.ById;

public class DeleteUserById : IRequest<bool>
{   
        public required long Id { get; init; }
}
