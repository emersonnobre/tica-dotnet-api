using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using TicaManager.Domain.Handlers;
using TicaManager.Domain.Requests;
using TicaManager.Domain.Responses;
using TicaManager.Domain.Services;

namespace TicaManager.Api.Controllers;

[ApiController]
[Route("/api/v1")]
[Produces("application/json")]
public class AccountController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromServices] ITokenService tokenService)
    {
        var token = tokenService.GenerateToken();
        return Ok(token);
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Response<string>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response<>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Response<>))]
    public async Task<IActionResult> Register(CreateUserRequest request, CreateUserHandler handler)
    {
        if (!request.IsValid)
            return BadRequest(Response<string>.NewFailure(request.Notifications));
        var response = await handler.Handle(request);
        return response.Success ? Created("/api/v1/user", response) : BadRequest(response);
    } 
}