using System.Text.Json.Serialization;

namespace RyftDotNet.Subscriptions.Request
{
    public sealed class SubscriptionPaymentMethodRequest
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        public SubscriptionPaymentMethodRequest(string id)
        {
            Id = id;
        }
    }
}
