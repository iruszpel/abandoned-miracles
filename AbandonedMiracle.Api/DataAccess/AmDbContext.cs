using AbandonedMiracle.Api.Entities.Identity;
using AbandonedMiracle.Api.Entities.Registrations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AbandonedMiracle.Api.DataAccess;

public class AmDbContext : IdentityDbContext<AmUser, AmRole, Guid>
{
    public DbSet<Registration> Registrations { get; set; } = default!;
    public AmDbContext(DbContextOptions<AmDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<AmRole>()
            .HasData(
                new AmRole
                {
                    Id = Guid.Parse("d9b0c1c0-5c5a-4b1f-8c1c-0d5c5a4b1f8c"),
                    Name = AmRole.ServiceWorker,
                    NormalizedName = "SERVICE WORKER"
                },
                new AmRole
                {
                    Id = Guid.Parse("d9b0c1c0-5c5a-4b1f-8c1c-0d5c5a4b1f8d"),
                    Name = AmRole.RegularUser,
                    NormalizedName = "REGULAR USER"
                }
            );
    }
}