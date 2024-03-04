
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Dns.Cloudflare.Dns;
using Abp.Dns.Cloudflare.Models;
using Microsoft.Extensions.Logging;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Pagination;
using Volo.Abp.Features;

namespace Abp.Dns.Cloudflare.Web.Pages.Cloudflare;

public class IndexModel : CloudflarePageModel
{
    private readonly ICloudflareCredentialService _cloudflareCredentialService;
    private readonly IFeatureChecker _featureChecker;
    private readonly ILogger<IndexModel> _logger;
    public PagerModel PagerModel { get; set; }
    public bool HidePager { get; set; } = false;
    

    public IndexModel( IFeatureChecker featureChecker, ICloudflareCredentialService cloudflareCredentialService, ILogger<IndexModel> logger)
    {
        _featureChecker = featureChecker;
        _cloudflareCredentialService = cloudflareCredentialService;
        _logger = logger;
    }


    public List<CloudflareCredential> Credentials { get; set; } = new List<CloudflareCredential>();
    public bool IsFeatureEnabled { get; set; } = false;

    public async Task OnGetAsync()
    {
        IsFeatureEnabled = await _featureChecker.IsEnabledAsync("Dns.Cloudflare");
        if (IsFeatureEnabled == false)
        {
            return;
        }
        var paginated = new PaginatedDto();
        var totalCount = await _cloudflareCredentialService.GetCredentialsCountAsync();
        _logger.LogInformation("Total count: {0}", totalCount);
        HidePager = totalCount > paginated.MaxResultCount;
        if (HidePager)
        {
            
            if (Request.Query["currentPage"].ToString().IsNullOrWhiteSpace() != true)
            {
                paginated.Skip = Request.Query["currentPage"].ToString().To<int>() - 1;
            }
            var currenPage = paginated.Skip + 1;
            var skip = paginated.Skip == 0 ? 1 : paginated.Skip * paginated.MaxResultCount;
            paginated.Skip = skip;
            PagerModel = new PagerModel(
                totalCount: totalCount,
                shownItemsCount: 1,
                currentPage: currenPage,
                pageSize: paginated.MaxResultCount,
                pageUrl: "/Cloudflare",
                sort:paginated.Sorting);
        }
      
        Credentials = await _cloudflareCredentialService.GetCredentialsAsync(paginated);
        _logger.LogInformation("Credentials: {0}", Credentials.Count);
    }
}
