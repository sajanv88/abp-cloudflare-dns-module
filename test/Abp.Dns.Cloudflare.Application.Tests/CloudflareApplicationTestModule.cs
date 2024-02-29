using Volo.Abp.Modularity;

namespace Abp.Dns.Cloudflare;

[DependsOn(
    typeof(CloudflareApplicationModule),
    typeof(CloudflareDomainTestModule)
    )]
public class CloudflareApplicationTestModule : AbpModule
{

}
