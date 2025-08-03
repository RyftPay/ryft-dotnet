using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class CaptureRequest
    {
        [property: JsonPropertyName("amount")]
        public long? Amount { get; set; }

        [property: JsonPropertyName("captureType")]
        public CaptureType? CaptureType { get; set; }

        [property: JsonPropertyName("platformFee")]
        public long? PlatformFee { get; set; }

        [property: JsonPropertyName("splits")]
        public SplitPaymentRequest? Splits { get; set; }

        [property: JsonPropertyName("settings")]
        public PaymentTransactionSettingsRequest? Settings { get; set; }
    }
}
