using AbandonedMiracle.Api.Commands.Registrations;
using FluentValidation;
using FluentValidation.Validators;

namespace AbandonedMiracle.Api.Validators.Registrations;

public class CreateRegistrationValidator : AbstractValidator<CreateRegistration.Command>
{
    public CreateRegistrationValidator()
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