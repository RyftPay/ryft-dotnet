using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class WalletDetailsRequest
    {
        [property: JsonPropertyName("type")]
        public WalletType Type { get; }

        [property: JsonPropertyName("googlePayToken")]
        public string? GooglePayToken { get; set; }

        [property: JsonPropertyName("applePayToken")]
        public string? ApplePayToken { get; set; }

        public WalletDetailsRequest(WalletType type)
        {
            Type = type;
        }
    }
}
