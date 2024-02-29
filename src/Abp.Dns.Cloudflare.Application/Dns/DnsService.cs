using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace Abp.Dns.Cloudflare.Dns;

public class DnsService: CloudflareAppService, IDnsService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<DnsService> _logger;
    public DnsService(HttpClient httpClient, IConfiguration configuration, ILogger<DnsService> logger)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _logger = logger;
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
}