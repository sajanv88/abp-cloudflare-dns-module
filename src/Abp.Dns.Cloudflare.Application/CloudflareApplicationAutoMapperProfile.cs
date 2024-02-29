using Abp.Dns.Cloudflare.Dns;
using AutoMapper;

namespace Abp.Dns.Cloudflare;

public class CloudflareApplicationAutoMapperProfile : Profile
{
    public CloudflareApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<DnsDto, DnsDto>();
        DestinationMemberNamingConvention = new PascalCaseNamingConvention();
    }
}
