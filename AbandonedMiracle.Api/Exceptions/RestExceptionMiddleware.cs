using Newtonsoft.Json;

namespace AbandonedMiracle.Api.Exceptions;

public class RestExceptionMiddleware
{
    private readonly ILogger<RestExceptionMiddleware> _logger;
    // middleware for handling RestException

    private readonly RequestDelegate _next;

    public RestExceptionMiddleware(RequestDelegate next, ILogger<RestExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (RestException ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, RestException ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)ex.StatusCode;

        var result = JsonConvert.SerializeObject(new { Errors = ex.Errors ?? new Dictionary<string, string[]>() });
        await context.Response.WriteAsync(result);
    }
}