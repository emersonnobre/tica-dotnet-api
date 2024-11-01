using Microsoft.AspNetCore.Mvc;
using TicaManager.Domain.Services;

namespace TicaManager.Api.Controllers;

[ApiController]
[Route("/api/v1")]
public class AccountController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromServices] ITokenService tokenService)
    {
        var token = tokenService.GenerateToken();
        return Ok(token);
    }
}