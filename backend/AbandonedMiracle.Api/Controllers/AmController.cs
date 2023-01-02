using AbandonedMiracle.Api.Helpers;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AbandonedMiracle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AmController : ControllerBase
{
    private readonly IMediator _mediator;

    public AmController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private async Task<ValidationResult> ValidateAsync<T>(T request) where T : notnull
    {
        if (HttpContext.RequestServices.GetService(typeof(IValidator<T>)) is not IValidator<T> validator)
            return new ValidationResult();
        return await validator.ValidateAsync(request);
    }

    protected async Task<IActionResult> HandleAsync<T>(T request) where T : notnull
    {
        var validationResult = await ValidateAsync(request);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors.ToErrorResult());
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}