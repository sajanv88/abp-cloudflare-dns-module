using Abp.Dns.Cloudflare.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Abp.Dns.Cloudflare.Permissions;

public class CloudflarePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CloudflarePermissions.GroupName, L("Permission:Cloudflare"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CloudflareResource>(name);
    }
}
