using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Abp.Dns.Cloudflare.EntityFrameworkCore;

public class CloudflareHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<CloudflareHttpApiHostMigrationsDbContext>
{
    public CloudflareHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<CloudflareHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Cloudflare"));

        return new CloudflareHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
