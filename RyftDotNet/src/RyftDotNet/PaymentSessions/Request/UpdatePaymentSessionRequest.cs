using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Common.Request;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class UpdatePaymentSessionRequest
    {
        [property: JsonPropertyName("amount")]
        public long? Amount { get; set; }

        [property: JsonPropertyName("customerEmail")]
        public string? CustomerEmail { get; set; }

        [property: JsonPropertyName("platformFee")]
        public long? PlatformFee { get; set; }

        [property: JsonPropertyName("splits")]
        public SplitPaymentRequest? Splits { get; set; }

        [property: JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; set; }

        [property: JsonPropertyName("captureFlow")]
        public string? CaptureFlow { get; set; }

        [property: JsonPropertyName("shippingDetails")]
        public ShippingDetailsRequest? ShippingDetails { get; set; }

        [property: JsonPropertyName("orderDetails")]
        public OrderDetailsRequest? OrderDetails { get; set; }

        [property: JsonPropertyName("paymentSettings")]
        public PaymentSettingsRequest? PaymentSettings { get; set; }
    }
}
