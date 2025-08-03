using System.Text.Json.Serialization;

namespace RyftDotNet.ApplePay.WebDomains
{
    public sealed class CreateApplePayWebDomainRequest
    {
        [property: JsonPropertyName("domainName")]
        public string DomainName { get; }

        public CreateApplePayWebDomainRequest(string domainName)
        {
            DomainName = domainName;
        }
    }
}
