using Abp.Dns.Cloudflare.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Abp.Dns.Cloudflare.Blazor.Server.Host;

public abstract class CloudflareComponentBase : AbpComponentBase
{
    protected CloudflareComponentBase()
    {
        LocalizationResource = typeof(CloudflareResource);
    }
}
