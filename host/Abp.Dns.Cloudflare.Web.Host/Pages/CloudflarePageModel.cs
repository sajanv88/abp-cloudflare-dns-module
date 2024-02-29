using Abp.Dns.Cloudflare.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Abp.Dns.Cloudflare.Pages;

public abstract class CloudflarePageModel : AbpPageModel
{
    protected CloudflarePageModel()
    {
        LocalizationResourceType = typeof(CloudflareResource);
    }
}
