using FluentValidation;

namespace AbandonedMiracle.Api.Validators.Reports;

public class ReportsValidator : AbstractValidator<Queries.Reports.Reports.Query>
{
    public ReportsValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0).LessThanOrEqualTo(100);
    }
}