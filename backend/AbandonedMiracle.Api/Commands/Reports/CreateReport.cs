using System.Net;
using System.Security.Claims;
using AbandonedMiracle.Api.DataAccess;
using AbandonedMiracle.Api.Dtos.Reports;
using AbandonedMiracle.Api.Entities.Reports;
using AbandonedMiracle.Api.Exceptions;
using AbandonedMiracle.Api.Services;
using AutoMapper;
using MediatR;

namespace AbandonedMiracle.Api.Commands.Reports;

public class CreateReport
{
    public class Command : IRequest<ReportDto>
    {
        public string Base64Image { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Latitude { get; set; } = default!;
        public string Longitude { get; set; } = default!;
    }

    public class Handler : IRequestHandler<Command, ReportDto>
    {
        private readonly AmDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public Handler(AmDbContext dbContext, IHttpContextAccessor httpContextAccessor, IMapper mapper,
            IImageService imageService)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task<ReportDto> Handle(Command request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier),
                    out var userId) || userId == Guid.Empty)
                throw new RestException(HttpStatusCode.InternalServerError, "User not found");

            var imageUrl = await _imageService.UploadImageAsync(request.Base64Image);

            var report = new Report()
            {
                ReportingUserId = userId,
                ReportDate = DateTime.UtcNow,
                ImageUrl = imageUrl,
                Description = request.Description,
                Address = request.Address,
                Longitude = request.Longitude,
                Latitude = request.Latitude,
                AnimalType = ReportAnimalType.Unknown,
                Status = ReportStatus.Open
            };

            _dbContext.Reports.Add(report);
            var success = await _dbContext.SaveChangesAsync(cancellationToken) > 0;
            if (success) return _mapper.Map<ReportDto>(report);
            throw new RestException(HttpStatusCode.InternalServerError, "Error saving Report");
        }
    }
}