using AbandonedMiracle.Api.Commands.Registrations;
using AbandonedMiracle.Api.Entities.Identity;
using AbandonedMiracle.Api.Queries.Registrations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbandonedMiracle.Api.Controllers;

public class ClientController : AmController
{
    public ClientController(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet("my-registrations"), Authorize(Roles = AmRole.RegularUser)]
    public async Task<IActionResult> GetMyRegistrations()
    {
        return await HandleAsync(new MyRegistrations.Query());
    }
    
    [HttpPost("create-registration"), Authorize(Roles = AmRole.RegularUser)]
    public async Task<IActionResult> CreateRegistration([FromForm] CreateRegistration.Command command)
    {
        return await HandleAsync(command);
    }
}