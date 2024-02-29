using Volo.Abp.Reflection;

namespace Abp.Dns.Cloudflare.Permissions;

public class CloudflarePermissions
{
    public const string GroupName = "Cloudflare";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(CloudflarePermissions));
    }
}
