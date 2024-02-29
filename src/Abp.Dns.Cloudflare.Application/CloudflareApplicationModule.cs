using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace Abp.Dns.Cloudflare;

[DependsOn(
    typeof(CloudflareDomainModule),
    typeof(CloudflareApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class CloudflareApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<CloudflareApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<CloudflareApplicationModule>(validate: true);
        });

        context.Services.AddTransient<HttpClient>(sp =>
        {
            var cloudflareConfig = context.Services.GetConfiguration().GetRequiredSection("Dns:Cloudflare");
            var cloudflareApiUrl = cloudflareConfig.GetValue<string>("Endpoint");
            var cloudflareApikey = cloudflareConfig.GetValue<string>("ApiKey");
            var cloudflareZoneId = cloudflareConfig.GetValue<string>("ZoneId");
            if (cloudflareApiUrl == null)
            {
                throw new ArgumentNullException("Dns:Cloudflare:Endpoint", "Cloudflare API endpoint is not configured");
            }

            if (cloudflareApikey == null)
            {
                throw new ArgumentNullException("Dns:Cloudflare:ApiKey", "Cloudflare API key is not configured");
            }

            if (cloudflareZoneId == null)
            {
                throw new ArgumentNullException("Dns:Cloudflare:ZoneId", "Cloudflare Zone ID is not configured");
            }
            
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(cloudflareApiUrl);
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {cloudflareApikey}");
            return httpClient;
        });
    }
}
