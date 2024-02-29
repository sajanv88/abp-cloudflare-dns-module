using Volo.Abp.Modularity;

namespace Abp.Dns.Cloudflare;

[DependsOn(
    typeof(CloudflareDomainModule),
    typeof(CloudflareTestBaseModule)
)]
public class CloudflareDomainTestModule : AbpModule
{

}
