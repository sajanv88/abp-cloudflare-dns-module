using System.Threading.Tasks;
using Abp.Dns.Cloudflare.Dns;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abp.Dns.Cloudflare.Web.Pages.Cloudflare.Dns;

public class Index : PageModel
{

    private readonly IDnsService _dnsService;

    public Index(IDnsService dnsService)
    {
        _dnsService = dnsService;
    }

    public string ZoneId { get; set; }
    
    public void OnGet(string zoneId)
    {
        ZoneId = zoneId;
    }

    private async Task LoadDnsList()
    {
        await _dnsService.GetDnsRecordsByZoneIdAsync(zoneId: ZoneId);
    }
}