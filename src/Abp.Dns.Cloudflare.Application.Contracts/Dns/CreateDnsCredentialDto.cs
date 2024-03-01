
using System.ComponentModel.DataAnnotations;

namespace Abp.Dns.Cloudflare.Dns;
public class CreateDnsCredentialDto
{
    [Required]
    [MinLength(3)]
    public string ZoneId { get; set; }
  
    [Required]
    [MinLength(3)]
    public string ApiKey { get; set; }
}