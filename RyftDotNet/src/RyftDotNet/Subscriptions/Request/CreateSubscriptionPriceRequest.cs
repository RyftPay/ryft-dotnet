using System.Text.Json.Serialization;

namespace RyftDotNet.Subscriptions.Request
{
    public sealed class CreateSubscriptionPriceRequest
    {
        [property: JsonPropertyName("amount")]
        public long Amount { get; }

        [property: JsonPropertyName("currency")]
        public string Currency { get; }

        [property: JsonPropertyName("interval")]
        public SubscriptionIntervalRequest Interval { get; }

        public CreateSubscriptionPriceRequest(
            long amount,
            string currency,
            SubscriptionIntervalRequest interval)
        {
            Amount = amount;
            Currency = currency;
            Interval = interval;
        }
    }
}
