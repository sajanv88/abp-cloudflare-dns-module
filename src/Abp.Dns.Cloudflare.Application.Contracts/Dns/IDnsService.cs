using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Abp.Dns.Cloudflare.Dns;

public interface IDnsService : IApplicationService
{
    Task<DnsDto> GetDnsRecordsByZoneIdAsync(string zoneId, DnsQueryParametersDto? queryParameters = null);
}