using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    /// <summary>
    /// An Apple Pay or Google Pay network token you have decrypted yourself.
    /// Requires the secret API key and <see cref="AuthenticationParametersRequest"/>, which carries the cryptogram.
    /// A Google Pay PAN_ONLY token is not a network token and must be sent as <see cref="CardDetailsRequest"/>.
    /// </summary>
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
