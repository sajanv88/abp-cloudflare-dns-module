using Volo.Abp.Ui.Branding;

namespace Abp.Dns.Cloudflare.Blazor.Host;

public class CloudflareHostBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Cloudflare";
}
