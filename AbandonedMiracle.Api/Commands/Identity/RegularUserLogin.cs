using System.Net;
using AbandonedMiracle.Api.Dtos.Identity;
using AbandonedMiracle.Api.Entities.Identity;
using AbandonedMiracle.Api.Exceptions;
using AbandonedMiracle.Api.Helpers;
using AbandonedMiracle.Api.Settings;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace AbandonedMiracle.Api.Commands.Identity;

public class RegularUserLogin
{
    public class Command : IRequest<RegularUserDto>
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }

    public class Handler : IRequestHandler<Command, RegularUserDto>
    {
        private readonly JwtSettings _jwtSettings;
        private readonly SignInManager<AmUser> _signInManager;
        private readonly UserManager<AmUser> _userManager;

        public Handler(UserManager<AmUser> userManager, SignInManager<AmUser> signInManager,
            IOptions<JwtSettings> options)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = options.Value;
        }

        public async Task<RegularUserDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null) throw new RestException(HttpStatusCode.Unauthorized);

            if (!await _userManager.IsInRoleAsync(user, AmRole.RegularUser))
                throw new RestException(HttpStatusCode.Unauthorized);

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded)
                return new RegularUserDto
                {
                    Token = JwtHelpers.GenerateJwtToken(user.Email, AmRole.RegularUser, _jwtSettings.Key)
                };

            throw new RestException(HttpStatusCode.Unauthorized);
        }
    }
}