using Abp.Dns.Cloudflare.Localization;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Services;
using Volo.Abp.Features;

namespace Abp.Dns.Cloudflare;

[Authorize]
[RequiresFeature("Dns.Cloudflare")]    
public abstract class CloudflareAppService : ApplicationService
{
    protected CloudflareAppService()
    {
        LocalizationResource = typeof(CloudflareResource);
        ObjectMapperContext = typeof(CloudflareApplicationModule);
    }
}
