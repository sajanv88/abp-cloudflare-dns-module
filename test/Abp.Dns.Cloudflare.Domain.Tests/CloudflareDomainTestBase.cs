using Volo.Abp.Modularity;

namespace Abp.Dns.Cloudflare;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class CloudflareDomainTestBase<TStartupModule> : CloudflareTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
