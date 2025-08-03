using System.Text.Json.Serialization;

namespace RyftDotNet.Disputes.Request
{
    public sealed class DisputeEvidenceTextRequest
    {
        [property: JsonPropertyName("billingAddress")]
        public string? BillingAddress { get; set; }

        [property: JsonPropertyName("shippingAddress")]
        public string? ShippingAddress { get; set; }

        [property: JsonPropertyName("duplicateTransaction")]
        public string? DuplicateTransaction { get; set; }

        [property: JsonPropertyName("uncategorised")]
        public string? Uncategorised { get; set; }
    }
}
