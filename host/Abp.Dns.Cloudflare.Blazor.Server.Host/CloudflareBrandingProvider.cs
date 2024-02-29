using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Abp.Dns.Cloudflare.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class CloudflareBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Cloudflare";
}
