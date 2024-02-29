using System.Text.Json.Serialization;

namespace Abp.Dns.Cloudflare.Dns;

public class DnsResultInfoDto
{
    public int Count { get; set; }
    public int Page { get; set; }
    [JsonPropertyName("per_page")]
    public int PerPage { get; set; }
    [JsonPropertyName("total_count")]
    public int TotalCount { get; set; }
}