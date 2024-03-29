﻿using Abp.Dns.Cloudflare.Models;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Abp.Dns.Cloudflare.EntityFrameworkCore;

[ConnectionStringName(CloudflareDbProperties.ConnectionStringName)]
public interface ICloudflareDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
    DbSet<CloudflareCredential> CloudflareCredentials { get; }
}
