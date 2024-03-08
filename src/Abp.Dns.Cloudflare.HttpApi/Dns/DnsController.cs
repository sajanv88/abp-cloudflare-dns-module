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
    
    [Route("zones/{zoneId}")]
    [HttpGet]
    public async Task<DnsDto> GetDnsRecordsByZoneIdAsync(string zoneId, [FromQuery] DnsQueryParametersDto? dnsQueryParameters = null)
    {
        return await _dnsService.GetDnsRecordsByZoneIdAsync(zoneId, dnsQueryParameters);
    }

    
}
