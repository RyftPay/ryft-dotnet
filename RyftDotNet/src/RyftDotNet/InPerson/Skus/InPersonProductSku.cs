using System;
using System.Text.Json.Serialization;
using RyftDotNet.InPerson.Products;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.InPerson.Skus
{
    public sealed class InPersonProductSku : IEquatable<InPersonProductSku>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("name")]
        public string Name { get; }

        [property: JsonPropertyName("country")]
        public string Country { get; }

        [property: JsonPropertyName("totalAmount")]
        public int TotalAmount { get; }

        [property: JsonPropertyName("currency")]
        public string Currency { get; }

        [property: JsonPropertyName("status")]
        public InPersonProductStatus Status { get; }

        [property: JsonPropertyName("productId")]
        public string ProductId { get; }

        [property:
            JsonPropertyName("createdTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CreatedTimestamp { get; }

        [property:
            JsonPropertyName("lastUpdatedTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset LastUpdatedTimestamp { get; }

        public InPersonProductSku(
            string id,
            string name,
            string country,
            int totalAmount,
            string currency,
            InPersonProductStatus status,
            string productId,
            DateTimeOffset createdTimestamp,
            DateTimeOffset lastUpdatedTimestamp)
        {
            Id = id;
            Name = name;
            Country = country;
            TotalAmount = totalAmount;
            Currency = currency;
            Status = status;
            ProductId = productId;
            CreatedTimestamp = createdTimestamp;
            LastUpdatedTimestamp = lastUpdatedTimestamp;
        }

        public bool Equals(InPersonProductSku? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && Name == other.Name
                   && Country == other.Country
                   && TotalAmount == other.TotalAmount
                   && Currency == other.Currency
                   && Status.Equals(other.Status)
                   && ProductId == other.ProductId
                   && CreatedTimestamp.Equals(other.CreatedTimestamp)
                   && LastUpdatedTimestamp.Equals(other.LastUpdatedTimestamp));

        public override bool Equals(object? obj)
            => obj is InPersonProductSku other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Name);
            hashCode.Add(Country);
            hashCode.Add(TotalAmount);
            hashCode.Add(Currency);
            hashCode.Add(Status);
            hashCode.Add(ProductId);
            hashCode.Add(CreatedTimestamp);
            hashCode.Add(LastUpdatedTimestamp);
            return hashCode.ToHashCode();
        }
    }
}
