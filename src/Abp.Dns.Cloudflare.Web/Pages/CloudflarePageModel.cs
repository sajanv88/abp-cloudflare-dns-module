using Abp.Dns.Cloudflare.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Abp.Dns.Cloudflare.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class CloudflarePageModel : AbpPageModel
{
    protected CloudflarePageModel()
    {
        LocalizationResourceType = typeof(CloudflareResource);
        ObjectMapperContext = typeof(CloudflareWebModule);
    }
}
