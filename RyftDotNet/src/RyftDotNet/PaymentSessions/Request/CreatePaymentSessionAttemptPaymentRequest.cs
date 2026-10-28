using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class CreatePaymentSessionAttemptPaymentRequest
    {
        [property: JsonPropertyName("paymentMethod")]
        public PaymentRequestPaymentMethod? PaymentMethod { get; set; }

        /// <summary>
        /// Requires <see cref="CreatePaymentSessionRequest.AuthenticationParameters"/>.
        /// </summary>
        [property: JsonPropertyName("walletNetworkToken")]
        public WalletNetworkTokenRequest? WalletNetworkToken { get; set; }

        public CreatePaymentSessionAttemptPaymentRequest(
            PaymentRequestPaymentMethod? paymentMethod = null)
        {
            PaymentMethod = paymentMethod;
        }
    }
}
