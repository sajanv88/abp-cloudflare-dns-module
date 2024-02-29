using Volo.Abp.Bundling;

namespace Abp.Dns.Cloudflare.Blazor.Host;

public class CloudflareBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
