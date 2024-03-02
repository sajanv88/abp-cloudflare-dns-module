using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Dns.Cloudflare.Models;
using Volo.Abp.Application.Services;

namespace Abp.Dns.Cloudflare.Dns;

public interface IDnsService : IApplicationService
{
    Task<DnsDto> GetZonesAsync();
    Task CreateDnsCredentialAsync(CreateDnsCredentialDto input);
    Task EnableDnsManagement(Guid tenantId);
    Task<List<CloudflareCredential>>  GetCredentialsAsync();
    Task<CloudflareCredential> GetCredentialAsync(Guid id);
    Task UpdateDnsCredentialAsync(Guid id, CreateDnsCredentialDto input);
    Task<DnsDto> GetDnsRecordsByZoneIdAsync(string zoneId);
    Task<CloudflareCredential> GetCredentialByTenantIdAsync(Guid tenantId);

    Task<List<CloudflareCredential>> GetZoneCredentialsForTenantsAsync(Guid id);

}