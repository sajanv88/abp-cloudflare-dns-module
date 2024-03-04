using System;
using System.Threading.Tasks;
using Abp.Dns.Cloudflare.Dns;
using Abp.Dns.Cloudflare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Abp.Dns.Cloudflare.Web.Pages.Cloudflare.Dns;

public class DeleteCredentialModel : PageModel
{
    [BindProperty] public CloudflareCredential Input { get; set; }
    private readonly ICloudflareCredentialService _cloudflareCredentialService;
    private readonly ILogger<DeleteCredentialModel> _logger;
    

    
    public DeleteCredentialModel(ICloudflareCredentialService cloudflareCredentialService, 
        ILogger<DeleteCredentialModel> logger)
    {
        _cloudflareCredentialService = cloudflareCredentialService;
        _logger = logger;
    }

    
    public async Task OnGetAsync(Guid credentialId)
    {
        Input = await _cloudflareCredentialService.GetCredentialAsync(credentialId);
        _logger.LogInformation("Credential Modal Loaded with credential: {credential}", Input.Id);
    }
    
    public async Task<IActionResult> OnPostAsync(Guid credentialId)
    {
        if (credentialId == Guid.Empty)
        {
            throw new NullReferenceException("CloudflareCredential is null");
        }
        _logger.LogInformation("Deleting DNS Credential with id: {id}", credentialId);
        await _cloudflareCredentialService.DeleteDnsCredentialAsync(credentialId);

        return new AcceptedResult();
    }
}