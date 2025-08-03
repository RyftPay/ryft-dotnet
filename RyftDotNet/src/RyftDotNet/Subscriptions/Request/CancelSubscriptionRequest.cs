using System.Text.Json.Serialization;

namespace RyftDotNet.Subscriptions.Request
{
    public sealed class CancelSubscriptionRequest
    {
        [property: JsonPropertyName("reason")]
        public string? Reason { get; set; }
    }
}
