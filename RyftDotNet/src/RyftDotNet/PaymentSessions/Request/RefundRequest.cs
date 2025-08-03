using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class RefundRequest
    {
        [property: JsonPropertyName("amount")]
        public long? Amount { get; set; }

        [property: JsonPropertyName("reason")]
        public string? Reason { get; set; }

        [property: JsonPropertyName("refundPlatformFee")]
        public bool? RefundPlatformFee { get; set; }

        [property: JsonPropertyName("splits")]
        public SplitPaymentRequest? Splits { get; set; }

        [property: JsonPropertyName("captureTransaction")]
        public TransactionIdRequest? CaptureTransaction { get; set; }

        [property: JsonPropertyName("platformSettings")]
        public PaymentPlatformSettingsRequest? PlatformSettings { get; set; }
    }
}
