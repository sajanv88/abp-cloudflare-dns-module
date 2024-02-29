using System.Collections.Generic;

namespace Abp.Dns.Cloudflare.Dns;

public class DnsDto
{
    public List<DnsErrorDto> Errors { get; set; } = new List<DnsErrorDto>();
    public List<DnsErrorDto> Messages { get; set; } = new List<DnsErrorDto>();
    public bool Success { get; set; } = false;
    
    public DnsResultInfoDto ResultInfo { get; set; } = new DnsResultInfoDto();
    public List<DnsResultDto> Result { get; set; } = new List<DnsResultDto>();
}