using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Dns.Cloudflare.Models;
using Volo.Abp.Application.Services;

namespace Abp.Dns.Cloudflare.Dns;

public interface ICloudflareCredentialService : IApplicationService
{
    Task CreateDnsCredentialAsync(CreateDnsCredentialDto input);
    Task UpdateDnsCredentialAsync(Guid id, CreateDnsCredentialDto input);
    Task DeleteDnsCredentialAsync(Guid id);
    Task<List<CloudflareCredential>> GetCredentialsAsync(PaginatedDto filter);
    Task<long> GetCredentialsCountAsync();
    Task<CloudflareCredential> GetCredentialAsync(Guid id);
    Task<CloudflareCredential> GetCredentialByTenantIdAsync(Guid tenantId);
    Task<List<CloudflareCredential>> GetZoneCredentialsForTenantsAsync(Guid id);
}