using Abp.Dns.Cloudflare.Localization;
using Volo.Abp.Application.Services;

namespace Abp.Dns.Cloudflare;

public abstract class CloudflareAppService : ApplicationService
{
    protected CloudflareAppService()
    {
        LocalizationResource = typeof(CloudflareResource);
        ObjectMapperContext = typeof(CloudflareApplicationModule);
    }
}
