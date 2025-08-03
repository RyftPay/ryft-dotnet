using System.Text.Json.Serialization;

namespace RyftDotNet.ApplePay.Sessions
{
    public sealed class CreateApplePayWebSessionRequest
    {
        [property: JsonPropertyName("displayName")]
        public string DisplayName { get; }

        [property: JsonPropertyName("domainName")]
        public string DomainName { get; }

        public CreateApplePayWebSessionRequest(
            string displayName,
            string domainName)
        {
            DisplayName = displayName;
            DomainName = domainName;
        }
    }
}
