using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace Abp.Dns.Cloudflare.Dns;

[Area(CloudflareRemoteServiceConsts.ModuleName)]
[RemoteService(Name = CloudflareRemoteServiceConsts.RemoteServiceName)]
[Route("api/Cloudflare/dns")]
public class DnsController : CloudflareController, IDnsService
{
    private readonly IDnsService _dnsService;

    public DnsController(IDnsService dnsService)
    {
        _dnsService = dnsService;
    }
    
    [HttpGet]
    public async Task<DnsDto> GetZonesAsync()
    {
        return await _dnsService.GetZonesAsync();
    }
}
