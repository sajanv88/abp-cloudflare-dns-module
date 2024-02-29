using System;
using System.Text.Json.Serialization;

namespace Abp.Dns.Cloudflare.Dns;

public class DnsResultDto
{
    public string Content { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool Proxied { get; set; } = false;
    public string Type { get; set; } = string.Empty;
    [JsonPropertyName("zone_id")]
    public string ZoneId { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    [JsonPropertyName("created_on")]
    public string CreatedOn { get; set; } = string.Empty;
    public string Id { get; set; } = string.Empty;
    public bool Locked { get; set; } = false;
    [JsonPropertyName("modified_on")]
    public string ModifiedOn { get; set; } = string.Empty;
    [JsonPropertyName("zone_name")]
    public string ZoneName { get; set; } = string.Empty;
    public bool Proxiable { get; set; } = false;
    public string[] Tags { get; set; } = Array.Empty<string>();
    [JsonPropertyName("ttl")]
    public int TTL { get; set; }
    
}