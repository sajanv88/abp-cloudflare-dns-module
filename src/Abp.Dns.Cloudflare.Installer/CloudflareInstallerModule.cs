using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Abp.Dns.Cloudflare;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class CloudflareInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CloudflareInstallerModule>();
        });
    }
}
