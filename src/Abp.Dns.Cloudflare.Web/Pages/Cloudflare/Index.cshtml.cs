
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Dns.Cloudflare.Dns;
using Abp.Dns.Cloudflare.Models;
using Volo.Abp.Features;

namespace Abp.Dns.Cloudflare.Web.Pages.Cloudflare;

public class IndexModel : CloudflarePageModel
{
    private readonly IDnsService _dnsService;
    private readonly IFeatureChecker _featureChecker;

    public IndexModel(IDnsService dnsService, IFeatureChecker featureChecker)
    {
        _dnsService = dnsService;
        _featureChecker = featureChecker;
    }


    public List<CloudflareCredential> Credentials { get; set; } = new List<CloudflareCredential>();
    public bool IsFeatureEnabled { get; set; } = false;

    public async Task OnGetAsync()
    {
        IsFeatureEnabled = await _featureChecker.IsEnabledAsync("Dns.Cloudflare");
        Credentials = await _dnsService.GetCredentialsAsync();
    }
}
