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
    protected IMediator Mediator;

    public AmController(IMediator mediator)
    {
        Mediator = mediator;
    }

    private async Task<ValidationResult> ValidateAsync<T>(T request)
    {
        var validator = HttpContext.RequestServices.GetService(typeof(IValidator<T>)) as IValidator<T>;
        if (validator is null)
            return new ValidationResult();
        return await validator.ValidateAsync(request);
    }

    protected async Task<IActionResult> HandleAsync<T>(T request)
    {
        var validationResult = await ValidateAsync(request);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors.ToErrorResult());
        var result = await Mediator.Send(request);
        return Ok(result);
    }
}