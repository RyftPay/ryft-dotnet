using System.Text.Json.Serialization;

namespace RyftDotNet.Subscriptions.Request
{
    public sealed class SubscriptionIntervalRequest
    {
        [property: JsonPropertyName("unit")]
        public IntervalUnit Unit { get; }

        [property: JsonPropertyName("count")]
        public int Count { get; }

        [property: JsonPropertyName("times")]
        public int? Times { get; set; }

        public SubscriptionIntervalRequest(IntervalUnit unit, int count)
        {
            Unit = unit;
            Count = count;
        }
    }
}
