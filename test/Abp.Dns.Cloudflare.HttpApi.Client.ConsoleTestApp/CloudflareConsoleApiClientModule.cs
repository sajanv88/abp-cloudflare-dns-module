using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Abp.Dns.Cloudflare;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CloudflareHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class CloudflareConsoleApiClientModule : AbpModule
{

}
