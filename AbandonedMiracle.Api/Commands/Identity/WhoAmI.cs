using System.Net;
using AbandonedMiracle.Api.Dtos.Identity;
using AbandonedMiracle.Api.Entities.Identity;
using AbandonedMiracle.Api.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AbandonedMiracle.Api.Commands.Identity;

public class WhoAmI
{
    public class Query : IRequest<UserDto>
    {}
    
    public class Handler : IRequestHandler<Query, UserDto>
    {
        private readonly UserManager<AmUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Handler(UserManager<AmUser> userManager, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext!.User);
            if (user is null)
                throw new RestException(HttpStatusCode.InternalServerError, "User not found");
            return _mapper.Map<UserDto>(user);
        }
    }
}