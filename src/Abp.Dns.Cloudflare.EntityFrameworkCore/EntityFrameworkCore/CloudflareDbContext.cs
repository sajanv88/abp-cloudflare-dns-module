using Abp.Dns.Cloudflare.Models;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Abp.Dns.Cloudflare.EntityFrameworkCore;

[ConnectionStringName(CloudflareDbProperties.ConnectionStringName)]
public class CloudflareDbContext : AbpDbContext<CloudflareDbContext>, ICloudflareDbContext
{
   public DbSet<CloudflareCredential> CloudflareCredentials { get; set; }

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
