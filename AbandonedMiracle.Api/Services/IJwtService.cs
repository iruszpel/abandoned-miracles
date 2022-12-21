using AbandonedMiracle.Api.Entities.Identity;

namespace AbandonedMiracle.Api.Services;

public interface IJwtService
{
    Task<string> GenerateJwtToken(AmUser user);
}