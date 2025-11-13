using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Orders
{
    public sealed class InPersonOrderShipping
    {
        [JsonPropertyName("address")]
        public InPersonOrderShippingAddress? Address { get; }

        [JsonPropertyName("contact")]
        public InPersonOrderShippingContact? Contact { get; }

        [JsonPropertyName("method")]
        public InPersonOrderShippingMethod? Method { get; }

        public InPersonOrderShipping(
            InPersonOrderShippingAddress? address,
            InPersonOrderShippingContact? contact,
            InPersonOrderShippingMethod? method)
        {
            Address = address;
            Contact = contact;
            Method = method;
        }
    }
}
