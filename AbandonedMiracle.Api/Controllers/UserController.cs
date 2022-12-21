using AbandonedMiracle.Api.Commands.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbandonedMiracle.Api.Controllers;

public class UserController : AmController
{
    public UserController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] Login.Command command)
    {
        return await HandleAsync(command);
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] Register.Command command)
    {
        return await HandleAsync(command);
    }
    
    [HttpGet, Authorize]
    public async Task<IActionResult> WhoAmI()
    {
        return await HandleAsync(new WhoAmI.Query());
    }
}