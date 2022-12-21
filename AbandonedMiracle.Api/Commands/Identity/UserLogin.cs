using System.Net;
using AbandonedMiracle.Api.Dtos.Identity;
using AbandonedMiracle.Api.Entities.Identity;
using AbandonedMiracle.Api.Exceptions;
using AbandonedMiracle.Api.Helpers;
using AbandonedMiracle.Api.Services;
using AbandonedMiracle.Api.Settings;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace AbandonedMiracle.Api.Commands.Identity;

public class UserLogin
{
    public class Command : IRequest<UserDto>
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }

    public class Handler : IRequestHandler<Command, UserDto>
    {
        private readonly SignInManager<AmUser> _signInManager;
        private readonly IJwtService _jwtService;
        private readonly UserManager<AmUser> _userManager;

        public Handler(UserManager<AmUser> userManager, SignInManager<AmUser> signInManager,
            IJwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        public async Task<UserDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user?.Email == null) throw new RestException(HttpStatusCode.Unauthorized);

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded)
                return new UserDto
                {
                    Email = user.Email,
                    Token = await _jwtService.GenerateJwtToken(user)
                };

            throw new RestException(HttpStatusCode.Unauthorized);
        }
    }
}