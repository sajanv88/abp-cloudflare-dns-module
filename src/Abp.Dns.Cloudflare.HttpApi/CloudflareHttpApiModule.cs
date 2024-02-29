using Localization.Resources.AbpUi;
using Abp.Dns.Cloudflare.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Abp.Dns.Cloudflare;

[DependsOn(
    typeof(CloudflareApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class CloudflareHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(CloudflareHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<CloudflareResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
