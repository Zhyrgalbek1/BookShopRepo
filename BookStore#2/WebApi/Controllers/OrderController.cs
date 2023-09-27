using Application.Orders.Commands;
using Application.Orders.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IMediator mediator, ILogger<OrderController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [SwaggerOperation("Посмотреть заказы")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllOrderQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [SwaggerOperation("Изменить свойства заказа")]
        [HttpPatch("Update")]
        public async Task<IActionResult> Update(UpdateOrderCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [SwaggerOperation("Удалить заказ по 'ID'")]
        [HttpDelete("DeleteByIdOrder")]
        public async Task<IActionResult> Delete(DeleteOrderByIdCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
