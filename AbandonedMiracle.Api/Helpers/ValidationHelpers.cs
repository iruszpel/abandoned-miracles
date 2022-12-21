using FluentValidation.Results;

namespace AbandonedMiracle.Api.Helpers;

public static class ValidationHelpers
{
    public static object ToErrorResult(this IEnumerable<ValidationFailure> failures)
    {
        return new
        {
            Errors = failures.Select(x => new { x.PropertyName, x.ErrorMessage }).GroupBy(x => x.PropertyName)
                .ToDictionary(x => x.Key, x => x.Select(y => y.ErrorMessage).ToArray())
        };
    }
}