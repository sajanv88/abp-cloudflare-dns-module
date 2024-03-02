using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Abp.Dns.Cloudflare.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Features;

namespace Abp.Dns.Cloudflare.Dns;

public class DnsService: CloudflareAppService, IDnsService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<DnsService> _logger;
    private readonly IRepository<CloudflareCredential, Guid> _cloudflareCredentialRepository;
    public DnsService(
        HttpClient httpClient,
        IConfiguration configuration,
        ILogger<DnsService> logger, IRepository<CloudflareCredential, Guid> cloudflareCredentialRepository)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _logger = logger;
        _cloudflareCredentialRepository = cloudflareCredentialRepository;
    }
    
    public async Task<DnsDto> GetZonesAsync()
    {
        var zoneId = _configuration["Dns:Cloudflare:ZoneId"];
        var path = _httpClient.BaseAddress + CloudflareEndpointPath.GetZones.Replace("{zone_id}", zoneId);
        _logger.LogInformation("Requesting....: {path}", path);
        try
        {
            var response = await _httpClient.GetAsync(path);
            return await response.Content.ReadFromJsonAsync<DnsDto>() 
                   ?? throw new UserFriendlyException("Error getting DNS", "No content returned");
            
        }catch(Exception e)
        {
            _logger.LogError(e, "Error getting DNS: {message}", e.Message);
            throw new UserFriendlyException("Error getting DNS", e.Message);
        }
    }

    public async Task CreateDnsCredentialAsync(CreateDnsCredentialDto input)
    {
        var credential = new CloudflareCredential() { ApiKey = input.ApiKey, ZoneId = input.ZoneId };
        await _cloudflareCredentialRepository.InsertAsync(credential);
    }

    public  Task EnableDnsManagement(Guid tenantId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<CloudflareCredential>> GetCredentialsAsync()
    {
        return await _cloudflareCredentialRepository.GetListAsync();
    }

    public async Task<CloudflareCredential> GetCredentialAsync(Guid id)
    {
        return await _cloudflareCredentialRepository.GetAsync(id);
    }

    public async Task UpdateDnsCredentialAsync(Guid credentialId, CreateDnsCredentialDto input)
    {
        var existingCredential = await _cloudflareCredentialRepository.GetAsync(credentialId);
        if (existingCredential == null)
        {
            throw new UserFriendlyException("Credential not found", "400");
        }
        existingCredential.ApiKey = input.ApiKey;
        existingCredential.ZoneId = input.ZoneId;
        await _cloudflareCredentialRepository.UpdateAsync(existingCredential);
    }

    public async Task<DnsDto> GetDnsRecordsByZoneIdAsync(string zoneId)
    {
        throw new NotImplementedException();
    }

    
    public Task<CloudflareCredential> GetCredentialByTenantIdAsync(Guid tenantId)
    {
        throw new NotImplementedException();
    }

    public Task<List<CloudflareCredential>> GetZoneCredentialsForTenantsAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}