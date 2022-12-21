using System.Net;
using System.Security.Claims;
using AbandonedMiracle.Api.DataAccess;
using AbandonedMiracle.Api.Dtos.Registrations;
using AbandonedMiracle.Api.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AbandonedMiracle.Api.Queries.Registrations;

public class MyRegistrations
{
    public class Query : IRequest<IEnumerable<RegistrationDto>>
    {
    }

    public class Handler : IRequestHandler<Query, IEnumerable<RegistrationDto>>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AmDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(IHttpContextAccessor httpContextAccessor, AmDbContext dbContext, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RegistrationDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier),
                    out var userId) || userId == Guid.Empty)
                throw new RestException(HttpStatusCode.InternalServerError, "User not found");

            var registrations = await _dbContext.Registrations.Where(x => x.RegisteringUserId == userId)
                .OrderByDescending(x => x.RegistrationDate).ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<RegistrationDto>>(registrations);
        }
    }
}