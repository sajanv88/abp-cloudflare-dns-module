using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Dns.Cloudflare.Models;
using Microsoft.Extensions.Logging;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Abp.Dns.Cloudflare.Dns;

public class CloudflareCredentialService: CloudflareAppService, ICloudflareCredentialService
{
    private readonly ILogger<CloudflareCredentialService> _logger;
    private readonly IRepository<CloudflareCredential, Guid> _cloudflareCredentialRepository;

    public CloudflareCredentialService(ILogger<CloudflareCredentialService> logger, IRepository<CloudflareCredential, Guid> cloudflareCredentialRepository)
    {
        _logger = logger;
        _cloudflareCredentialRepository = cloudflareCredentialRepository;
    }

    public async Task CreateDnsCredentialAsync(CreateDnsCredentialDto input)
    {
        _logger.LogInformation("Creating new credential");
        var credential = new CloudflareCredential() { ApiKey = input.ApiKey, ZoneId = input.ZoneId };
        await _cloudflareCredentialRepository.InsertAsync(credential);
    }

    public async Task UpdateDnsCredentialAsync(Guid id, CreateDnsCredentialDto input)
    {
        var existingCredential = await _cloudflareCredentialRepository.GetAsync(id);
        if (existingCredential == null)
        {
            throw new UserFriendlyException("Credential not found", "400");
        }
        existingCredential.ApiKey = input.ApiKey;
        existingCredential.ZoneId = input.ZoneId;
        await _cloudflareCredentialRepository.UpdateAsync(existingCredential);
    }

    public async Task DeleteDnsCredentialAsync(Guid id)
    {
        await _cloudflareCredentialRepository.DeleteAsync(id);
    }

    public async Task<List<CloudflareCredential>> GetCredentialsAsync(PaginatedDto filter)
    {
        var skip = filter.Skip;
        var maxResultCount = filter.MaxResultCount;
        var sort = filter.Sorting ?? "asc";
        return await _cloudflareCredentialRepository.GetPagedListAsync(skipCount:skip, maxResultCount: maxResultCount, sorting: sort);
    }

    public async Task<long> GetCredentialsCountAsync()
    {
        return await _cloudflareCredentialRepository.GetCountAsync();
    }

    public async Task<CloudflareCredential> GetCredentialAsync(Guid id)
    {
        return await _cloudflareCredentialRepository.GetAsync(id);
    }
}