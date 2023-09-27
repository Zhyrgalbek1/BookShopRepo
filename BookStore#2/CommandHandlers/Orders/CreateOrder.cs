using Application.Orders.Dtos;
using Domain.Entities;
using Domain.Enums;
using Domain.Repos;
using Domain.Repositories;
using Infrastructure.Shared;
using MediatR;

namespace Application.Orders.Commands
{

    public record CreateOrderCommand : IRequest<OrderDto>
    {
        public required string Username { get; init; }
        public required string Adress { get; init; }
    }

    internal class CreateOrderHandler : IRequestHandler<CreateOrderCommand, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepo _userRepository;

        public CreateOrderHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IUserRepo userRepository)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username, cancellationToken);
            if (user is null) throw new ArgumentNullException(nameof(user));

            var books = user.Basket.Books.ToList();
            if (!books.Any()) throw new ArgumentNullException(nameof(books));

            var price = books.Sum(book => book.Price);

            var order = new Order
            {
                UserId = user.Id,
                Adress = request.Adress,
                Books = books,
                TotalPrice = price,
                Status = OrderStatus.delivered,
                User = user,
            };

            var orderDto = new OrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                Adress = order.Adress,
                Books = order.Books,
                TotalPrice = order.TotalPrice,
                Status = order.Status,
            };

            await _orderRepository.Create(order);
            user.Basket.Books.Clear();
            await _unitOfWork.CommitAsync();

            return orderDto;
        }
    }

}
