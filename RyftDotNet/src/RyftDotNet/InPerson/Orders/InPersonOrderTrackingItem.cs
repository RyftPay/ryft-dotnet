using System;
using System.Text.Json.Serialization;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.InPerson.Orders
{
    public sealed class InPersonOrderTrackingItem
    {
        [JsonPropertyName("carrier")]
        public string Carrier { get; }

        [JsonPropertyName("reference")]
        public string Reference { get; }

        [property:
            JsonPropertyName("shippedTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
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
