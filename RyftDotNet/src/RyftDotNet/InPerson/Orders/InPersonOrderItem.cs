using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Orders
{
    public sealed class InPersonOrderItem : IEquatable<InPersonOrderItem>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("name")]
        public string Name { get; }

        [property: JsonPropertyName("totalAmountPerUnit")]
        public long TotalAmountPerUnit { get; }

        [property: JsonPropertyName("taxAmountPerUnit")]
        public long TaxAmountPerUnit { get; }

        [property: JsonPropertyName("quantity")]
        public int Quantity { get; }

        public InPersonOrderItem(
            string id,
            string name,
            long totalAmountPerUnit,
            long taxAmountPerUnit,
            int quantity)
        {
            Id = id;
            Name = name;
            TotalAmountPerUnit = totalAmountPerUnit;
            TaxAmountPerUnit = taxAmountPerUnit;
            Quantity = quantity;
        }

        public bool Equals(InPersonOrderItem? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && Name == other.Name
                   && TotalAmountPerUnit == other.TotalAmountPerUnit
                   && TaxAmountPerUnit == other.TaxAmountPerUnit
                   && Quantity == other.Quantity);

        public override bool Equals(object? obj)
            => obj is InPersonOrderItem other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Name);
            hashCode.Add(TotalAmountPerUnit);
            hashCode.Add(TaxAmountPerUnit);
            hashCode.Add(Quantity);
            return hashCode.ToHashCode();
        }
    }
}
