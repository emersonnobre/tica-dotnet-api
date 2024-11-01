using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicaManager.Domain.Entities;
using TicaManager.Domain.Handlers;
using TicaManager.Domain.Requests;
using TicaManager.Domain.Responses;

namespace TicaManager.Api.Controllers;

[ApiController]
[Route("api/v1/employees")]
[Produces("application/json")]
public class EmployeeController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Response<CreateEmployeeResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response<>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Response<>))]
    public async Task<IActionResult> Create(CreateEmployeeRequest request, CreateEmployeeHandler handler)
    {
        if (!request.IsValid)
            return BadRequest(Response<Employee>.NewFailure(request.Notifications));
        var response = await handler.Handle(request);
        return response.Success ? Created(new Uri("/api/v1/employees"), response) : BadRequest(response);    
    }

    [Authorize(Roles = "admin")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<IEnumerator<GetEmployeesResponse>>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Response<>))]
    public async Task<IActionResult> Get([FromServices]GetEmployeesHandler handler)
    {
        Console.WriteLine(User.Identity?.Name);
        var response = await handler.Handle();
        return Ok(response);
    }
}