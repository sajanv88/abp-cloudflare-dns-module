using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Abp.Dns.Cloudflare;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(CloudflareDomainSharedModule)
)]
public class CloudflareDomainModule : AbpModule
{
  
}
