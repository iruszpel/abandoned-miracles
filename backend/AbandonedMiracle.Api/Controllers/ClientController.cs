using AbandonedMiracle.Api.Commands.Reports;
using AbandonedMiracle.Api.Entities.Identity;
using AbandonedMiracle.Api.Queries.Reports;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbandonedMiracle.Api.Controllers;

public class ClientController : AmController
{
    public ClientController(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet("my-reports"), Authorize(Roles = AmRole.RegularUser)]
    public async Task<IActionResult> GetMyReports()
    {
        return await HandleAsync(new MyReports.Query());
    }
    
    [HttpPost("create-report"), Authorize(Roles = AmRole.RegularUser)]
    public async Task<IActionResult> CreateReport([FromForm] CreateReport.Command command)
    {
        return await HandleAsync(command);
    }
}