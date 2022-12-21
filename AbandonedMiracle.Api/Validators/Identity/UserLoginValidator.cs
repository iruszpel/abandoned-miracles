using AbandonedMiracle.Api.Commands.Identity;
using FluentValidation;

namespace AbandonedMiracle.Api.Validators.Identity;

public class UserLoginValidator : AbstractValidator<UserLogin.Command>
{
    public UserLoginValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}