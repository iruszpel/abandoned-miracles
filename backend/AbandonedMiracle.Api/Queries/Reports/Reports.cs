using AbandonedMiracle.Api.DataAccess;
using AbandonedMiracle.Api.Dtos.Reports;
using AbandonedMiracle.Api.Entities.Reports;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AbandonedMiracle.Api.Queries.Reports;

public class Reports
{
    public class Query : IRequest<PagedReportDto>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class Handler : IRequestHandler<Query, PagedReportDto>
    {
        private readonly AmDbContext _amDbContext;
        private readonly IMapper _mapper;

        public Handler(AmDbContext amDbContext, IMapper mapper)
        {
            _amDbContext = amDbContext;
            _mapper = mapper;
        }

        public async Task<PagedReportDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var baseQuery = _amDbContext.Reports.Where(x => x.Status == ReportStatus.Open);
            var reports = await baseQuery
                .OrderByDescending(x => x.ReportDate)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .ProjectTo<ReportDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            var count = await baseQuery.CountAsync(cancellationToken: cancellationToken);

            return new PagedReportDto()
            {
                Items = reports,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = count,
                TotalPages = (int)Math.Ceiling(count / (double)request.PageSize)
            };
        }
    }
}