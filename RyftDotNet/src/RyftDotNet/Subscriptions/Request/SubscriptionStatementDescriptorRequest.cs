using System.Text.Json.Serialization;

namespace RyftDotNet.Subscriptions.Request
{
    public sealed class SubscriptionStatementDescriptorRequest
    {
        [property: JsonPropertyName("descriptor")]
        public string Descriptor { get; }

        [property: JsonPropertyName("city")]
        public string City { get; }

        public SubscriptionStatementDescriptorRequest(string descriptor, string city)
        {
            Descriptor = descriptor;
            City = city;
        }
    }
}
