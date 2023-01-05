using AbandonedMiracle.Api.Commands.Reports;
using FluentValidation;
using FluentValidation.Validators;

namespace AbandonedMiracle.Api.Validators.Reports;

public class CreateReportValidator : AbstractValidator<CreateReport.Command>
{
    public CreateReportValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(2000);
        
        RuleFor(x => x.Address)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Latitude)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Longitude)
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(x => x.Base64Image)
            .NotEmpty()
            .MaximumLength(10_000_000);
    }
}