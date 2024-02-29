using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Abp.Dns.Cloudflare;

[Dependency(ReplaceServices = true)]
public class CloudflareBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Cloudflare";
}
