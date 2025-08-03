using System.Text.Json.Serialization;

namespace RyftDotNet.Subscriptions.Request
{
    public sealed class CreateSubscriptionCustomerRequest
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        public CreateSubscriptionCustomerRequest(string id)
        {
            Id = id;
        }
    }
}
