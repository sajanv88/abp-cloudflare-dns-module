using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Dns.Cloudflare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace Abp.Dns.Cloudflare.Dns;

[Area(CloudflareRemoteServiceConsts.ModuleName)]
[RemoteService(Name = CloudflareRemoteServiceConsts.RemoteServiceName)]
[Route("api/Cloudflare/credentials")]
public class CloudflareCredentialServiceController: CloudflareController, ICloudflareCredentialService
{
    private readonly ICloudflareCredentialService _cloudflareCredentialService;
    private readonly ILogger<CloudflareCredentialServiceController> _logger;
    
    public CloudflareCredentialServiceController(ICloudflareCredentialService cloudflareCredentialService, ILogger<CloudflareCredentialServiceController> logger)
    {
        _cloudflareCredentialService = cloudflareCredentialService;
        _logger = logger;
    }

    
    [HttpPost]
    public async Task CreateDnsCredentialAsync(CreateDnsCredentialDto input)
    {
        await _cloudflareCredentialService.CreateDnsCredentialAsync(input);
    }

    [Route("{id}")]
    [HttpPut]
    public async Task UpdateDnsCredentialAsync(Guid id, CreateDnsCredentialDto input)
    {
        await _cloudflareCredentialService.UpdateDnsCredentialAsync(id, input);
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task DeleteDnsCredentialAsync(Guid id)
    {
        await _cloudflareCredentialService.DeleteDnsCredentialAsync(id);
    }

    [HttpGet]
    public async Task<List<CloudflareCredential>> GetCredentialsAsync(PaginatedDto? filter)
    {
        return await _cloudflareCredentialService.GetCredentialsAsync(filter);
    }

    [Route("getTotalCount")]
    [HttpGet]
    public Task<long> GetCredentialsCountAsync()
    {
        return _cloudflareCredentialService.GetCredentialsCountAsync();
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<CloudflareCredential> GetCredentialAsync(Guid id)
    {
        return await _cloudflareCredentialService.GetCredentialAsync(id);
    }

    [Route("tenants/{tenantId}")]
    [HttpGet]
    public async Task<CloudflareCredential> GetCredentialByTenantIdAsync(Guid tenantId)
    {
        return await _cloudflareCredentialService.GetCredentialByTenantIdAsync(tenantId);
    }

    [Route("tenants/zones/{id}")]
    [HttpGet]
    public async Task<List<CloudflareCredential>> GetZoneCredentialsForTenantsAsync(Guid id)
    {
        return await _cloudflareCredentialService.GetZoneCredentialsForTenantsAsync(id); 
    }
    
    
}