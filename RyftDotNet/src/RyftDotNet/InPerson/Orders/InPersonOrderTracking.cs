using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Utility;

namespace RyftDotNet.InPerson.Orders
{
    public sealed class InPersonOrderTracking : IEquatable<InPersonOrderTracking>
    {
        [property: JsonPropertyName("carrier")]
        public string Carrier { get; }

        [property: JsonPropertyName("trackingNumber")]
        public string TrackingNumber { get; }

        [property: JsonPropertyName("items")]
        public IEnumerable<InPersonOrderTrackingItem> Items { get; }

        public InPersonOrderTracking(
            string carrier,
            string trackingNumber,
            IEnumerable<InPersonOrderTrackingItem> items)
        {
            Carrier = carrier;
            TrackingNumber = trackingNumber;
            Items = items;
        }

        public bool Equals(InPersonOrderTracking? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Carrier == other.Carrier
                   && TrackingNumber == other.TrackingNumber
                   && Utilities.SequenceEqual(Items, other.Items));

        public override bool Equals(object? obj)
            => obj is InPersonOrderTracking other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Carrier);
            hashCode.Add(TrackingNumber);
            hashCode.Add(Items);
            return hashCode.ToHashCode();
        }
    }
}