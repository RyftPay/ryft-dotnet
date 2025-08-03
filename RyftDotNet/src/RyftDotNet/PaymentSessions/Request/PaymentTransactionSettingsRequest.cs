using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class PaymentTransactionSettingsRequest
    {
        [property: JsonPropertyName("platform")]
        public PaymentPlatformSettingsRequest? Platform { get; set; }
    }
}
