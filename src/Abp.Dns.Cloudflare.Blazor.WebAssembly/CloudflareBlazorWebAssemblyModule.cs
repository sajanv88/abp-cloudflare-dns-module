using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace Abp.Dns.Cloudflare.Blazor.WebAssembly;

[DependsOn(
    typeof(CloudflareBlazorModule),
    typeof(CloudflareHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class CloudflareBlazorWebAssemblyModule : AbpModule
{

}
