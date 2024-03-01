using Abp.Dns.Cloudflare.Models;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Abp.Dns.Cloudflare.EntityFrameworkCore;

[DependsOn(
    typeof(CloudflareDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class CloudflareEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<CloudflareDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddDefaultRepositories(includeAllEntities: true);
        });
    }
}
