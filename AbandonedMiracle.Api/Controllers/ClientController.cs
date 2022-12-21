using AbandonedMiracle.Api.Queries.Registrations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AbandonedMiracle.Api.Controllers;

public class ClientController : AmController
{
    public ClientController(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet("my-registrations")]
    public async Task<IActionResult> GetMyRegistrations()
    {
        return await HandleAsync(new MyRegistrations.Query());
    }
}