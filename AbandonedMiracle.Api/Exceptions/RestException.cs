using System.Net;

namespace AbandonedMiracle.Api.Exceptions;

public class RestException : Exception
{
    public RestException(HttpStatusCode statusCode, object? errors = null)
    {
        StatusCode = statusCode;
        Errors = errors;
    }

    public HttpStatusCode StatusCode { get; set; }
    public object? Errors { get; set; }
}