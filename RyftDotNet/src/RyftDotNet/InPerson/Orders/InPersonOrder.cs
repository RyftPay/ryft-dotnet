using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Utility;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.InPerson.Orders
{
    public sealed class InPersonOrder : IEquatable<InPersonOrder>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("status")]
        public InPersonOrderStatus Status { get; }

        [property: JsonPropertyName("totalAmount")]
        public long TotalAmount { get; }

        [property: JsonPropertyName("taxAmount")]
        public long TaxAmount { get; }

        [property: JsonPropertyName("currency")]
        public string Currency { get; }

        [property: JsonPropertyName("items")]
        public IEnumerable<InPersonOrderItem> Items { get; }

        [property: JsonPropertyName("customer")]
        public InPersonOrderCustomer Customer { get; }

        [property: JsonPropertyName("shipping")]
        public InPersonOrderShipping? Shipping { get; }

        [property: JsonPropertyName("tracking")]
        public InPersonOrderTracking? Tracking { get; }

        [property: JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; }

        [property:
            JsonPropertyName("createdTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CreatedTimestamp { get; }

        [property:
            JsonPropertyName("lastUpdatedTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset LastUpdatedTimestamp { get; }

        public InPersonOrder(
            string id,
            InPersonOrderStatus status,
            long totalAmount,
            long taxAmount,
            string currency,
            IEnumerable<InPersonOrderItem> items,
            InPersonOrderCustomer customer,
            DateTimeOffset createdTimestamp,
            DateTimeOffset lastUpdatedTimestamp,
            InPersonOrderShipping? shipping = null,
            InPersonOrderTracking? tracking = null,
            IDictionary<string, string>? metadata = null)
        {
            Id = id;
            Status = status;
            TotalAmount = totalAmount;
            TaxAmount = taxAmount;
            Currency = currency;
            Items = items;
            Customer = customer;
            CreatedTimestamp = createdTimestamp;
            LastUpdatedTimestamp = lastUpdatedTimestamp;
            Shipping = shipping;
            Tracking = tracking;
            Metadata = metadata;
        }

        public bool Equals(InPersonOrder? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && Status.Equals(other.Status)
                   && TotalAmount == other.TotalAmount
                   && TaxAmount == other.TaxAmount
                   && Currency == other.Currency
                   && Utilities.SequenceEqual(Items, other.Items)
                   && Customer.Equals(other.Customer)
                   && Equals(Shipping, other.Shipping)
                   && Equals(Tracking, other.Tracking)
                   && Utilities.DictionaryEquals(Metadata, other.Metadata)
                   && CreatedTimestamp.Equals(other.CreatedTimestamp)
                   && LastUpdatedTimestamp.Equals(other.LastUpdatedTimestamp));

        public override bool Equals(object? obj)
            => obj is InPersonOrder other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Status);
            hashCode.Add(TotalAmount);
            hashCode.Add(TaxAmount);
            hashCode.Add(Currency);
            hashCode.Add(Items);
            hashCode.Add(Customer);
            hashCode.Add(Shipping);
            hashCode.Add(Tracking);
            hashCode.Add(Metadata);
            hashCode.Add(CreatedTimestamp);
            hashCode.Add(LastUpdatedTimestamp);
            return hashCode.ToHashCode();
        }
    }
}
