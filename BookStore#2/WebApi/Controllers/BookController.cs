using CommandHandlers.Books.Create;
using CommandHandlers.Books.Delete.ById;
using CommandHandlers.Books.Delete.ByTitle;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QueryHandlers.Books.GetAll;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers;


[ApiController, Route("api/book")]
public class BookController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [SwaggerOperation("Посмотреть все книги")]
    [HttpGet("GetAllBooks")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllBooksQuery();
        var books = await _mediator.Send(query, cancellationToken);
      
        return Ok(books);
    }

    [SwaggerOperation("Добавить книгу (Админ)")]
    [Authorize(Roles = "Admin")]
    [HttpPost("AddBook")]
    public async Task<IActionResult> Create(CreateBook request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);

        return Ok();
    }

    [SwaggerOperation("Удалить по названию (Админ)")]
    [Authorize(Roles = "Admin")]
    [HttpDelete("DeleteByTitle")]
    public async Task<IActionResult> DeleteByTitle(DeleteBookByTitle request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);

        return Ok();
    }

    [SwaggerOperation("Удалить по ID (Админ)")]
    [Authorize(Roles = "Admin")]
    [HttpDelete("DeleteById")]
    public async Task<IActionResult> DeleteById(DeleteBookById request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);

        return Ok();
    }
}
