using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Abp.Dns.Cloudflare.EntityFrameworkCore;

public class CloudflareHttpApiHostMigrationsDbContext : AbpDbContext<CloudflareHttpApiHostMigrationsDbContext>
{
    public CloudflareHttpApiHostMigrationsDbContext(DbContextOptions<CloudflareHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureCloudflare();
    }
}
