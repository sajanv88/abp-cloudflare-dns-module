using Abp.Dns.Cloudflare.Localization;
using Volo.Abp.Application.Services;
using Volo.Abp.Features;

namespace Abp.Dns.Cloudflare;

[RequiresFeature("Dns.Cloudflare")]    
public abstract class CloudflareAppService : ApplicationService
{
    protected CloudflareAppService()
    {
        LocalizationResource = typeof(CloudflareResource);
        ObjectMapperContext = typeof(CloudflareApplicationModule);
    }
}
