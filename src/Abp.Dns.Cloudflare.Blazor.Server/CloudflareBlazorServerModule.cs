using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace Abp.Dns.Cloudflare.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(CloudflareBlazorModule)
    )]
public class CloudflareBlazorServerModule : AbpModule
{

}
