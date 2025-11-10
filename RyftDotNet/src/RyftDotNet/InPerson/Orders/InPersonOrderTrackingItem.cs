using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Orders
{
    public sealed class InPersonOrderTrackingItem : IEquatable<InPersonOrderTrackingItem>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("quantity")]
        public int Quantity { get; }

        public InPersonOrderTrackingItem(string id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }

        public bool Equals(InPersonOrderTrackingItem? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && Quantity == other.Quantity);

        public override bool Equals(object? obj)
            => obj is InPersonOrderTrackingItem other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Id, Quantity);
    }
}