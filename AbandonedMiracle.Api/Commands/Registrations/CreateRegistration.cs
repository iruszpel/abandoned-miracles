using System.Net;
using System.Security.Claims;
using AbandonedMiracle.Api.DataAccess;
using AbandonedMiracle.Api.Dtos.Registrations;
using AbandonedMiracle.Api.Entities.Registrations;
using AbandonedMiracle.Api.Exceptions;
using AutoMapper;
using MediatR;

namespace AbandonedMiracle.Api.Commands.Registrations;

public class CreateRegistration
{
    public class Command : IRequest<RegistrationDto>
    {
        public IFormFile Image { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Address { get; set; } = default!;
    }

    public class Handler : IRequestHandler<Command, RegistrationDto>
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
        public async Task<RegistrationDto> Handle(Command request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier),
                    out var userId) || userId == Guid.Empty)
                throw new RestException(HttpStatusCode.InternalServerError, "User not found");

            var registration = new Registration()
            {
                RegisteringUserId = userId,
                RegistrationDate = DateTime.UtcNow,
                Title = request.Title,
                Description = request.Description,
                Address = request.Address,
                ImageId = null,
                AnimalType = RegistrationAnimalType.Unknown,
                ProcessingStatus = RegistrationProcessingStatus.Pending
            };
            
            _dbContext.Registrations.Add(registration);
            var success = await _dbContext.SaveChangesAsync(cancellationToken) > 0;
            if (success) return _mapper.Map<RegistrationDto>(registration);
            throw new RestException(HttpStatusCode.InternalServerError, "Error saving registration");
        }
    }
}