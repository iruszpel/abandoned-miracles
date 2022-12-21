using AbandonedMiracle.Api.Commands.Identity;
using AbandonedMiracle.Api.Entities.Identity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace AbandonedMiracle.Api.Validators.Identity;

public class UserRegisterValidator : AbstractValidator<Register.Command>
{
    public UserRegisterValidator(UserManager<AmUser> userManager)
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MustAsync(async (email, _) => await userManager.FindByEmailAsync(email) is null)
            .WithMessage("Email already exists");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(128);

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .Equal(x => x.Password)
            .WithMessage("Passwords do not match");
    }
}