using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Abp.Dns.Cloudflare;

[DependsOn(
    typeof(CloudflareApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class CloudflareHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(CloudflareApplicationContractsModule).Assembly,
            CloudflareRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CloudflareHttpApiClientModule>();
        });

    }
}
