using AbandonedMiracle.Api.Commands.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AbandonedMiracle.Api.Controllers;

public class RegularUserController : AmController
{
    public RegularUserController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] RegularUserLogin.Command command)
    {
        return await HandleAsync(command);
    }
}