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
    
    private static Guid _credentialId { get; set; }
    
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
        _credentialId = credentialId;
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (Input == null)
        {
            throw new NullReferenceException("CloudflareCredential is null");
        }
        _logger.LogInformation("Deleting DNS Credential with id: {id}", _credentialId);
        await _cloudflareCredentialService.DeleteDnsCredentialAsync(_credentialId);
        _credentialId = Guid.Empty;
        return new AcceptedResult();
    }
}