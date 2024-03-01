using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Dns.Cloudflare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace Abp.Dns.Cloudflare.Dns;

[Area(CloudflareRemoteServiceConsts.ModuleName)]
[RemoteService(Name = CloudflareRemoteServiceConsts.RemoteServiceName)]
[Route("api/Cloudflare/dns")]
public class DnsController : CloudflareController, IDnsService
{
    private readonly IDnsService _dnsService;

    public DnsController(IDnsService dnsService)
    {
        _dnsService = dnsService;
    }
    
    [HttpGet]
    public async Task<DnsDto> GetZonesAsync()
    {
        return await _dnsService.GetZonesAsync();
    }

    
    [HttpPost]
    public async  Task CreateDnsCredentialAsync(CreateDnsCredentialDto input)
    {
         await _dnsService.CreateDnsCredentialAsync(input);
    }

    [Route("enableDnsManagement/tenant/{tenantId}")]
    [HttpGet]
    public Task EnableDnsManagement(Guid tenantId)
    {
        throw new NotImplementedException();
    }

    [Route("allCredentials")]
    [HttpGet]
    public async Task<List<CloudflareCredential>> GetCredentialsAsync()
    {
        return await _dnsService.GetCredentialsAsync();        
    }

    [Route("credential/{id}")]
    [HttpGet]
    public Task<CloudflareCredential> GetCredentialAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    [Route("credential/tenant/{tenantId}")]
    [HttpGet]
    public Task<CloudflareCredential> GetCredentialByTenantIdAsync(Guid tenantId)
    {
        throw new NotImplementedException();
    }
}
