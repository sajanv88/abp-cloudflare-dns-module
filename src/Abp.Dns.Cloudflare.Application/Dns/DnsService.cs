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
    private readonly ILogger<DnsService> _logger;
    private readonly ICloudflareCredentialService _cloudflareCredentialService;
    public DnsService(
        HttpClient httpClient,
        ILogger<DnsService> logger, ICloudflareCredentialService cloudflareCredentialService)
    {
        _httpClient = httpClient;
        _logger = logger;
        _cloudflareCredentialService = cloudflareCredentialService;
    }

    public async Task<DnsDto> GetDnsRecordsByZoneIdAsync(string zoneId)
    { 
        var path = _httpClient.BaseAddress + CloudflareEndpointPath.GetZones.Replace("{zone_id}", zoneId);
        var credential = await _cloudflareCredentialService.GetCredentialByZoneIdAsync(zoneId);
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {credential.ApiKey}");
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
}