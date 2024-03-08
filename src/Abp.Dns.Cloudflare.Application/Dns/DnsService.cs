using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Logging;
using Volo.Abp;
using Volo.Abp.ObjectMapping;


namespace Abp.Dns.Cloudflare.Dns;

public class DnsService: CloudflareAppService, IDnsService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<DnsService> _logger;
    private readonly ICloudflareCredentialService _cloudflareCredentialService;
    private readonly IObjectMapper<CloudflareApplicationModule> _mapper;
    public DnsService(
        HttpClient httpClient,
        ILogger<DnsService> logger, ICloudflareCredentialService cloudflareCredentialService, IObjectMapper<CloudflareApplicationModule> mapper)
    {
        _httpClient = httpClient;
        _logger = logger;
        _cloudflareCredentialService = cloudflareCredentialService;
        _mapper = mapper;
    }

    public async Task<DnsDto> GetDnsRecordsByZoneIdAsync(string zoneId, DnsQueryParametersDto? queryParameters = null)
    { 
        var path = _httpClient.BaseAddress + CloudflareEndpointPath.GetZones.Replace("{zone_id}", zoneId);
        var credential = await _cloudflareCredentialService.GetCredentialByZoneIdAsync(zoneId);
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {credential.ApiKey}");
        try
        {
            if (queryParameters is not null)
            {
                var properties = from p in queryParameters.GetType().GetProperties()
                    where p.GetValue(queryParameters, null) != null
                    select p.Name.ToSnakeCase() + "=" + HttpUtility.UrlEncode(p.GetValue(queryParameters, null).ToString());
                
                var queryString = String.Join("&", properties.ToArray());
                _logger.LogInformation($"queryString: {queryString}");       
                path = $"{path}?{queryString}";
            }
            _logger.LogInformation($"Path: {path}");
     
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