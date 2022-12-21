using Microsoft.AspNetCore.Identity;

namespace AbandonedMiracle.Api.Entities.Identity;

public class AmRole : IdentityRole<Guid>
{
    public static readonly string RegularUser = "Regular User";
    public static readonly string ServiceWorker = "Service Worker";
}