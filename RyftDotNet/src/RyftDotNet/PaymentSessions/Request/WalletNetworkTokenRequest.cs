using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class WalletNetworkTokenRequest
    {
        [property: JsonPropertyName("number")]
        public string Number { get; }

        [property: JsonPropertyName("expiryMonth")]
        public string ExpiryMonth { get; }

        [property: JsonPropertyName("expiryYear")]
        public string ExpiryYear { get; }

        [property: JsonPropertyName("name")]
        public string? Name { get; set; }

        [property: JsonPropertyName("walletType")]
        public WalletType WalletType { get; }

        public WalletNetworkTokenRequest(
            string number,
            string expiryMonth,
            string expiryYear,
            WalletType walletType)
        {
            Number = number;
            ExpiryMonth = expiryMonth;
            ExpiryYear = expiryYear;
            WalletType = walletType;
        }
    }
}
