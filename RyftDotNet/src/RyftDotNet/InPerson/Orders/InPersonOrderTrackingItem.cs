using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Orders
{
    public sealed class InPersonOrderTrackingItem
    {
        [JsonPropertyName("carrier")]
        public string Carrier { get; }

        [JsonPropertyName("reference")]
        public string Reference { get; }

        [JsonPropertyName("shippedTimestamp")]
        public DateTimeOffset ShippedTimestamp { get; }

        public InPersonOrderTrackingItem(
            string carrier,
            string reference,
            DateTimeOffset shippedTimestamp)
        {
            Carrier = carrier;
            Reference = reference;
            ShippedTimestamp = shippedTimestamp;
        }
    }
}
