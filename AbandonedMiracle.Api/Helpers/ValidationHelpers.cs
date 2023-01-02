using System.Diagnostics;
using System.Reflection;
using FluentValidation;
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

    public static IServiceCollection RegisterValidators(this IServiceCollection services)
    {
        var validators = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.BaseType is { IsGenericType: true } &&
                        t.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>));

        foreach (var validator in validators)
        {
            var validatedType = validator.BaseType!.GetGenericArguments()[0];
            var interfaceType = typeof(IValidator<>).MakeGenericType(validatedType);
            services.AddScoped(interfaceType, validator);
        }

        return services;
    }
}