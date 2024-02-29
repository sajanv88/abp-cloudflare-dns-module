namespace Abp.Dns.Cloudflare.Dns;

public class DnsErrorDto
{
    public int Code { get; set; }
    public string Message { get; set; } = string.Empty;
}