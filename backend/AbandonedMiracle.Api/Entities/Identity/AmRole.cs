using Microsoft.AspNetCore.Identity;

namespace AbandonedMiracle.Api.Entities.Identity;

public class AmRole : IdentityRole<Guid>
{
    public const string RegularUser = "Regular User";
    public const string ServiceWorker = "Service Worker";
}