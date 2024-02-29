namespace Abp.Dns.Cloudflare;

public static class CloudflareDbProperties
{
    public static string DbTablePrefix { get; set; } = "Cloudflare";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Cloudflare";
}
