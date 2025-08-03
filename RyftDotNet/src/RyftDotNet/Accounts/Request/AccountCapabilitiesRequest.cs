using System.Text.Json.Serialization;

namespace RyftDotNet.Accounts.Request
{
    public sealed class AccountCapabilitiesRequest
    {
        [JsonPropertyName("amexPayments")]
        public AccountCapabilityRequestItem AmexPayments { get; }

        public AccountCapabilitiesRequest(AccountCapabilityRequestItem amexPayments)
        {
            AmexPayments = amexPayments;
        }
    }
}
