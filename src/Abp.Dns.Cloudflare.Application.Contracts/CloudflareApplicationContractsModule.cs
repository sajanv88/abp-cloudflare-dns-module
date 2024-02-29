using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Abp.Dns.Cloudflare;

[DependsOn(
    typeof(CloudflareDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class CloudflareApplicationContractsModule : AbpModule
{

}
