using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class PaymentPlatformSettingsRequest
    {
        [property: JsonPropertyName("paymentFees")]
        public PaymentFeeAllocationSettingsRequest PaymentFeeAllocationSettings { get; }

        public PaymentPlatformSettingsRequest(
            PaymentFeeAllocationSettingsRequest paymentFeeAllocationSettings)
        {
            PaymentFeeAllocationSettings = paymentFeeAllocationSettings;
        }
    }
}
