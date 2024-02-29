using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Abp.Dns.Cloudflare.Pages;

public class IndexModel : CloudflarePageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
