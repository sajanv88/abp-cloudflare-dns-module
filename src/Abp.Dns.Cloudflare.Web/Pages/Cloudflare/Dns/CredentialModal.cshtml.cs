using System;
using System.Threading.Tasks;
using Abp.Dns.Cloudflare.Dns;
using Abp.Dns.Cloudflare.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Abp.Dns.Cloudflare.Web.Pages.Cloudflare.Dns;


public class CredentialModal : PageModel
{
    private readonly ICloudflareCredentialService _cloudflareCredentialService;
    private readonly ILogger<CredentialModal> _logger;

  
    public CredentialModal(ICloudflareCredentialService cloudflareCredentialService, 
        ILogger<CredentialModal> logger)
    {
        _cloudflareCredentialService = cloudflareCredentialService;
        _logger = logger;
    
    }
    
    public  CloudflareCredential CloudflareCredential { get; set; }

    [BindProperty] public CreateDnsCredentialDto Input { get; set; }
    
    public async Task OnGetAsync(Guid credentialId)
    {
        _logger.LogInformation("Credential Modal Loaded with id: {id}", credentialId);
        if (credentialId != Guid.Empty)
        {
         
            CloudflareCredential = await _cloudflareCredentialService.GetCredentialAsync(credentialId);
            _logger.LogInformation("Credential Modal Loaded with credential: {credential}",
                CloudflareCredential.ZoneId);
            Input = new CreateDnsCredentialDto()
                { ZoneId = CloudflareCredential.ZoneId, ApiKey = CloudflareCredential.ApiKey };
            await Task.CompletedTask;
        }
    
       
    }
    
    public async Task<IActionResult> OnPostCreateAsync()
    {
        _logger.LogInformation("Creating DNS Credential with input: {zone} and {apikey}", Input.ZoneId, Input.ApiKey);
        await _cloudflareCredentialService.CreateDnsCredentialAsync(Input);
        return new NoContentResult();
    }

    public async Task<IActionResult> OnPostEditAsync(Guid credentialId)
    {
        _logger.LogInformation("Credential Id: {id}", credentialId);
        _logger.LogInformation("Updating DNS Credential with input: {zone} and {apikey}", Input.ZoneId, Input.ApiKey);
        await _cloudflareCredentialService.UpdateDnsCredentialAsync(credentialId, Input);
        return new NoContentResult();
    }

}