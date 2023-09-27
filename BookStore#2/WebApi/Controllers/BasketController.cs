using Infrastructure.Baskets.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QueryHandlers.Baskets;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<BasketController> _logger;

    public BasketController(IMediator mediator, ILogger<BasketController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [SwaggerOperation("Добавить книгу в корзину")]
    [HttpPost("AddBookToBasket")]
    public async Task<IActionResult> Add(string title)
    {
        var username = HttpContext.User.FindFirstValue(ClaimTypes.Name) ?? string.Empty;
        if (username is null)
            return NotFound();
        var request = new AddBookToBasketCommand
        {
            Title = title,
            Username = username
        };

        var response = await _mediator.Send(request);

        if (response)
            return Ok("Book add basket");
        return BadRequest("");
    }

    [SwaggerOperation("Посмотреть книги в корзине")]
    [HttpPost("GetBooksFromBasket")]
    public async Task<IActionResult> Get()
    {
        var username = HttpContext.User.FindFirstValue(ClaimTypes.Name) ?? string.Empty;
        if (username is null)
            return NotFound();
        var request = new GetBooksFromBasketCommand
        {
            Username = username
        };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
