namespace Abp.Dns.Cloudflare.Dns;

public class PaginatedDto
{
    public int Skip { get; set; } = 0;
    public int MaxResultCount { get; set; } = 5;
    public string? Search { get; set; } = string.Empty;
    public string? Sorting { get; set; } = string.Empty;
}