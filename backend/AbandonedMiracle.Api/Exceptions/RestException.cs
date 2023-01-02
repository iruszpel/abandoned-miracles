using System.Net;

namespace AbandonedMiracle.Api.Exceptions;

public class RestException : Exception
{
    public RestException(HttpStatusCode statusCode, Dictionary<string, string[]>? errors = null)
    {
        StatusCode = statusCode;
        Errors = errors;
    }

    public RestException(HttpStatusCode statusCode, string error)
    {
        StatusCode = statusCode;
        Errors = new Dictionary<string, string[]> { { "error", new[] { error } } };
    }

    public HttpStatusCode StatusCode { get; set; }
    public Dictionary<string, string[]>? Errors { get; set; }
}