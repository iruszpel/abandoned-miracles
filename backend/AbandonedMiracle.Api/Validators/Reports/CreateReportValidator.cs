using AbandonedMiracle.Api.Commands.Reports;
using FluentValidation;
using FluentValidation.Validators;

namespace AbandonedMiracle.Api.Validators.Reports;

public class CreateReportValidator : AbstractValidator<CreateReport.Command>
{
    public CreateReportValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(2000);
        
        RuleFor(x => x.Address)
            .NotEmpty()
            .MaximumLength(200);
    }
}