using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Abp.Dns.Cloudflare.EntityFrameworkCore;

[ConnectionStringName(CloudflareDbProperties.ConnectionStringName)]
public class CloudflareDbContext : AbpDbContext<CloudflareDbContext>, ICloudflareDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public CloudflareDbContext(DbContextOptions<CloudflareDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureCloudflare();
    }
}
