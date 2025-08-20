using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class PaymentFeeAllocationSettingsRequest
    {
        [property: JsonPropertyName("interchange")]
        public FeeAllocationRequestItem? Interchange { get; set; }

        [property: JsonPropertyName("network")]
        public FeeAllocationRequestItem? Network { get; set; }

        [property: JsonPropertyName("processor")]
        public FeeAllocationRequestItem? Processor { get; set; }

        [property: JsonPropertyName("gateway")]
        public FeeAllocationRequestItem? Gateway { get; set; }

        [property: JsonPropertyName("combined")]
        public FeeAllocationRequestItem? Combined { get; set; }

        [property: JsonPropertyName("miscPassThrough")]
        public FeeAllocationRequestItem? MiscPassThrough { get; set; }
    }
}
