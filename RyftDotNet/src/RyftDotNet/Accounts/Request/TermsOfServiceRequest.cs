using System.Text.Json.Serialization;

namespace RyftDotNet.Accounts.Request
{
    public sealed class TermsOfServiceRequest
    {
        [property: JsonPropertyName("acceptance")]
        public TermsOfServiceAcceptanceRequest Acceptance { get; }

        public TermsOfServiceRequest(TermsOfServiceAcceptanceRequest acceptance)
        {
            Acceptance = acceptance;
        }
    }
}
