using System.Text.Json.Serialization;

namespace RyftDotNet.Subscriptions.Request
{
    public sealed class UpdateSubscriptionPriceRequest
    {
        [property: JsonPropertyName("amount")]
        public long? Amount { get; set; }

        [property: JsonPropertyName("interval")]
        public SubscriptionIntervalRequest? Interval { get; set; }
    }
}
