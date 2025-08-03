using System.Text.Json.Serialization;
using RyftDotNet.Common;
using RyftDotNet.Common.Request;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class AttemptPaymentRequest
    {
        [property: JsonPropertyName("clientSecret")]
        public string ClientSecret { get; }

        [property: JsonPropertyName("paymentMethodType")]
        public PaymentMethodType? PaymentMethodType { get; set; } = PaymentMethodType.Card;

        [property: JsonPropertyName("cardDetails")]
        public CardDetailsRequest? CardDetails { get; set; }

        [property: JsonPropertyName("walletDetails")]
        public WalletDetailsRequest? WalletDetails { get; set; }

        [property: JsonPropertyName("paymentMethod")]
        public AttemptPaymentPaymentMethodRequest? PaymentMethod { get; set; }

        [property: JsonPropertyName("paymentMethodOptions")]
        public AttemptPaymentPaymentMethodOptions? PaymentMethodOptions { get; set; }

        [property: JsonPropertyName("addressRequest")]
        public AddressRequest? BillingAddress { get; set; }

        [property: JsonPropertyName("customerDetails")]
        public AttemptPaymentCustomerDetails? CustomerDetails { get; set; }

        [property: JsonPropertyName("shippingDetails")]
        public ShippingDetailsRequest? ShippingDetails { get; set; }

        [property: JsonPropertyName("threeDsRequestDetails")]
        public ThreeDsRequestDetails? ThreeDsRequestDetails { get; set; }

        public AttemptPaymentRequest(string clientSecret)
        {
            ClientSecret = clientSecret;
        }
    }
}
