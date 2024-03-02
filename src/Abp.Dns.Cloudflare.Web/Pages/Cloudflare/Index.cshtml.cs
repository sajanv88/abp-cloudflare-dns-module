
using System.Collections.Generic;
using Abp.Dns.Cloudflare.Models;
namespace Abp.Dns.Cloudflare.Web.Pages.Cloudflare;

public class IndexModel : CloudflarePageModel
{

    
    public List<CloudflareCredential> CloudflareCredentials { get; set; } = new List<CloudflareCredential>();

    public async void OnGet()
    {
        
    }
}
