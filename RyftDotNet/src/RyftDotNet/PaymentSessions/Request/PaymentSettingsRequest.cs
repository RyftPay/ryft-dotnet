using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class PaymentSettingsRequest
    {
        [property: JsonPropertyName("paymentMethodOptions")]
        public PaymentMethodOptionSettingsRequest? PaymentMethodOptions { get; set; }

        [property: JsonPropertyName("platform")]
        public PaymentPlatformSettingsRequest? Platform { get; set; }
    }
}
