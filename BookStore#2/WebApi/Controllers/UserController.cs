using CommandHandlers.Users.Delete.ByTitle;
using CommandHandlers.Users.Delete.ById;
using CommandHandlers.Usesrs.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QueryHandlers.Users.Get.GetAll;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers;

[ApiController, Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("GetAllUsers")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllUsersRequest();
        var users = await _mediator.Send(query, cancellationToken);

        return Ok(users);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("GetByName")]
    public async Task<IActionResult> GetByName(GetUserByNameCommand command)
    {
        var user = await _mediator.Send(command);
        if (user is not null)
            return Ok(user);
        return NotFound();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("Update")]
    public async Task<IActionResult> Update(UpdateUserCommand command)
    {
        var user = await _mediator.Send(command);
        if (user is not null)
            return Ok(user);
        return NotFound();
    }


    [HttpDelete("DeleteByNames")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(DeleteUserByUsername command)
    {
        var response = await _mediator.Send(command);

        if (response == true)
            return Ok(response);
        return NotFound();
    }


    [HttpDelete("DeleteById")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Deleted(DeleteUserById command)
    {
        var response = await _mediator.Send(command);
        if (response == true)
            return Ok(response);
        return NotFound();
    }
}
