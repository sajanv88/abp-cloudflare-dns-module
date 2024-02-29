using System.Text.Json.Serialization;

namespace Abp.Dns.Cloudflare.Dns;

public class DnsMetaDto
{
    [JsonPropertyName("auto_added")]
    public bool AutoAdded { get; set; } = false;
    [JsonPropertyName("managed_by_apps")]
    public bool ManagedByApps { get; set; } = false;
    [JsonPropertyName("managed_by_argo_tunnel")]
    public bool ManagedByArgoTunnel { get; set; } = false; 
}