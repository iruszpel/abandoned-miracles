using AbandonedMiracle.Api.Commands.Reports;
using AbandonedMiracle.Api.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbandonedMiracle.Api.Controllers;

public class ServiceWorkerController : AmController
{
    public ServiceWorkerController(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpPost("close-report"), Authorize(Roles = AmRole.ServiceWorker)]
    public async Task<IActionResult> CloseReport([FromBody] CloseReport.Command command)
    {
        return await HandleAsync(command);
    }
    
}