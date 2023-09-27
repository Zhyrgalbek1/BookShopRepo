using Application.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers;

[Route("api/login")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IMediator mediator, ILogger<AuthController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [SwaggerOperation("Войти")]
    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginCommand command)
    {
        var token = await _mediator.Send(command) ?? string.Empty;
        return Ok(token);
    }

    [SwaggerOperation("Регистрация (Доступна в бете)")]
    [AllowAnonymous]
    [HttpPost("Register")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Register(CreateUserCommand command)
    {
        if (((int)command.Role) < 1 || ((int)command.Role) > 2)
            return BadRequest("Not the correct role");
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}
