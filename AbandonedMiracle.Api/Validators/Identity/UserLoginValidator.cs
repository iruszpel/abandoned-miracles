using AbandonedMiracle.Api.Commands.Identity;
using FluentValidation;

namespace AbandonedMiracle.Api.Validators.Identity;

public class UserLoginValidator : AbstractValidator<Login.Command>
{
    public UserLoginValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}