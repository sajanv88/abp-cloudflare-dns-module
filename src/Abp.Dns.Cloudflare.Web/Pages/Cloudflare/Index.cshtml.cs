
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Dns.Cloudflare.Dns;
using Abp.Dns.Cloudflare.Models;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Pagination;
using Volo.Abp.Features;

namespace Abp.Dns.Cloudflare.Web.Pages.Cloudflare;

public class IndexModel : CloudflarePageModel
{
    private readonly ICloudflareCredentialService _cloudflareCredentialService;
    private readonly IFeatureChecker _featureChecker;
    public PagerModel PagerModel { get; set; }  
    

    public IndexModel( IFeatureChecker featureChecker, ICloudflareCredentialService cloudflareCredentialService)
    {
        _featureChecker = featureChecker;
        _cloudflareCredentialService = cloudflareCredentialService;
    }


    public List<CloudflareCredential> Credentials { get; set; } = new List<CloudflareCredential>();
    public bool IsFeatureEnabled { get; set; } = false;

    public async Task OnGetAsync()
    {
        IsFeatureEnabled = await _featureChecker.IsEnabledAsync("Dns.Cloudflare");
        var paginated = new PaginatedDto();
        if (Request.Query["currentPage"].ToString().IsNullOrWhiteSpace() != true)
        {
            paginated.Skip = Request.Query["currentPage"].ToString().To<int>() - 1;
        }
        Credentials = await _cloudflareCredentialService.GetCredentialsAsync(paginated);
        var totalCount = await _cloudflareCredentialService.GetCredentialsCountAsync();
        PagerModel = new PagerModel(
            totalCount: totalCount,
            shownItemsCount: 1,
            currentPage: paginated.Skip + 1,
            pageSize: paginated.MaxResultCount,
            pageUrl: "/Cloudflare",
            sort:paginated.Sorting);
    }
}
