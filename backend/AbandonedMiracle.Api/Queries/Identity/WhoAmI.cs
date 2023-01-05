using System.Net;
using AbandonedMiracle.Api.Dtos.Identity;
using AbandonedMiracle.Api.Entities.Identity;
using AbandonedMiracle.Api.Exceptions;
using AbandonedMiracle.Api.Services;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AbandonedMiracle.Api.Queries.Identity;

public class WhoAmI
{
    public class Query : IRequest<UserDto>
    {
        public bool? RefreshToken { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, UserDto>
    {
        private readonly UserManager<AmUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtService _jwtService;

        public Handler(UserManager<AmUser> userManager, IMapper mapper, IHttpContextAccessor httpContextAccessor, IJwtService jwtService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _jwtService = jwtService;
        }

        public async Task<UserDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext!.User);
            if (user?.Email == null)
                throw new RestException(HttpStatusCode.InternalServerError, "User not found");
            if (request.RefreshToken is not null && request.RefreshToken.Value)
                return new UserWithTokenDto()
                {
                    Email = user.Email,
                    Token = await _jwtService.GenerateJwtToken(user)
                };
            return _mapper.Map<UserDto>(user);
        }
    }
}