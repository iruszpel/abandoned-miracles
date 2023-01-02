using System.Net;
using System.Security.Claims;
using AbandonedMiracle.Api.DataAccess;
using AbandonedMiracle.Api.Dtos.Reports;
using AbandonedMiracle.Api.Entities.Reports;
using AbandonedMiracle.Api.Exceptions;
using AutoMapper;
using MediatR;

namespace AbandonedMiracle.Api.Commands.Reports;

public class CreateReport
{
    public class Command : IRequest<ReportDto>
    {
        public IFormFile Image { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Address { get; set; } = default!;
    }

    public class Handler : IRequestHandler<Command, ReportDto>
    {
        private readonly AmDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public Handler(AmDbContext dbContext, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
        public async Task<ReportDto> Handle(Command request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier),
                    out var userId) || userId == Guid.Empty)
                throw new RestException(HttpStatusCode.InternalServerError, "User not found");

            var Report = new Report()
            {
                RegisteringUserId = userId,
                ReportDate = DateTime.UtcNow,
                Title = request.Title,
                Description = request.Description,
                Address = request.Address,
                ImageId = null,
                AnimalType = ReportAnimalType.Unknown,
                ProcessingStatus = ReportProcessingStatus.Pending
            };
            
            _dbContext.Reports.Add(Report);
            var success = await _dbContext.SaveChangesAsync(cancellationToken) > 0;
            if (success) return _mapper.Map<ReportDto>(Report);
            throw new RestException(HttpStatusCode.InternalServerError, "Error saving Report");
        }
    }
}