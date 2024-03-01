using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Abp.Dns.Cloudflare.Models;

public class CloudflareCredential: AggregateRoot<Guid>, IMultiTenant
{
    public Guid? TenantId { get; set; }
    [Required]
    public string ZoneId { get; set; } = string.Empty;
    [Required]
    public string ApiKey { get; set; } = string.Empty;
}
