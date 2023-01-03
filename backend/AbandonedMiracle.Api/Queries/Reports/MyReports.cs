using System.Net;
using System.Security.Claims;
using AbandonedMiracle.Api.DataAccess;
using AbandonedMiracle.Api.Dtos.Reports;
using AbandonedMiracle.Api.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AbandonedMiracle.Api.Queries.Reports;

public class MyReports
{
    public class Query : IRequest<IEnumerable<ReportDto>>
    {
    }

    public class Handler : IRequestHandler<Query, IEnumerable<ReportDto>>
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

        public async Task<IEnumerable<ReportDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier),
                    out var userId) || userId == Guid.Empty)
                throw new RestException(HttpStatusCode.InternalServerError, "User not found");

            var reports = await _dbContext.Reports.Where(x => x.ReportingUserId == userId)
                .OrderByDescending(x => x.ReportDate).ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<ReportDto>>(reports);
        }
    }
}