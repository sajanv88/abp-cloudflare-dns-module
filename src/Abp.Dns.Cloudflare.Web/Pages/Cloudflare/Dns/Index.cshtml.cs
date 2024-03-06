using System;
using System.Threading.Tasks;
using Abp.Dns.Cloudflare.Dns;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Abp.Dns.Cloudflare.Web.Pages.Cloudflare.Dns;

public class Index : PageModel
{

    private readonly IDnsService _dnsService;
    private readonly ICloudflareCredentialService _cloudflareCredentialService;
    private readonly ILogger<Index> _logger;
    public DnsDto DnsDto { get; set; } = new DnsDto();
    public bool Loading { get; set; } = true;
    public Index(IDnsService dnsService, ILogger<Index> logger,
        ICloudflareCredentialService cloudflareCredentialService)
    {
        _dnsService = dnsService;
        _logger = logger;
        _cloudflareCredentialService = cloudflareCredentialService;
    }


    
    public async Task OnGetAsync(string zoneId)
    {

        Loading = true;
        await LoadDnsList(zoneId);
    }

    private async Task LoadDnsList(string zoneId)
    {
       DnsDto = await _dnsService.GetDnsRecordsByZoneIdAsync(zoneId);
       Loading = false;
    }
}