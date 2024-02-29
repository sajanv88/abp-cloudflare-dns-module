using Abp.Dns.Cloudflare.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Abp.Dns.Cloudflare;

public abstract class CloudflareController : AbpControllerBase
{
    protected CloudflareController()
    {
        LocalizationResource = typeof(CloudflareResource);
    }
}
