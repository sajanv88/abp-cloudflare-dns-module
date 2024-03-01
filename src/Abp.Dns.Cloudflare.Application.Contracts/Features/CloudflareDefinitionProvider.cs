using Abp.Dns.Cloudflare.Localization;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Validation.StringValues;

namespace Abp.Dns.Cloudflare.Features;

public class CloudflareDefinitionProvider: FeatureDefinitionProvider
{
    public override void Define(IFeatureDefinitionContext context)
    {
        var group = context.AddGroup("Dns", L("CloudflareDnsManagementDisplayName"));      
        group.AddFeature(
            "Dns.Cloudflare", 
            "true", 
            L("CloudflareDnsManagementStatus"), 
            valueType: new ToggleStringValueType());
    }
    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CloudflareResource>(name);
    }
}