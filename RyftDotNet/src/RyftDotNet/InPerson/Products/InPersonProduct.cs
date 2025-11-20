using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Utility;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.InPerson.Products
{
    public sealed class InPersonProduct : IEquatable<InPersonProduct>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("name")]
        public string Name { get; }

        [property: JsonPropertyName("status")]
        public InPersonProductStatus Status { get; }

        [property: JsonPropertyName("description")]
        public string Description { get; }

        [property: JsonPropertyName("details")]
        public IDictionary<string, string>? Details { get; }

        [property:
            JsonPropertyName("createdTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CreatedTimestamp { get; }

        [property:
            JsonPropertyName("lastUpdatedTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset LastUpdatedTimestamp { get; }

        public InPersonProduct(
            string id,
            string name,
            InPersonProductStatus status,
            string description,
            DateTimeOffset createdTimestamp,
            DateTimeOffset lastUpdatedTimestamp,
            IDictionary<string, string>? details = null)
        {
            Id = id;
            Name = name;
            Status = status;
            Description = description;
            Details = details;
            CreatedTimestamp = createdTimestamp;
            LastUpdatedTimestamp = lastUpdatedTimestamp;
        }

        public bool Equals(InPersonProduct? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && Name == other.Name
                   && Status.Equals(other.Status)
                   && Description == other.Description
                   && Utilities.DictionaryEquals(Details, other.Details)
                   && CreatedTimestamp.Equals(other.CreatedTimestamp)
                   && LastUpdatedTimestamp.Equals(other.LastUpdatedTimestamp));

        public override bool Equals(object? obj)
            => obj is InPersonProduct other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Name);
            hashCode.Add(Status);
            hashCode.Add(Description);
            hashCode.Add(Details);
            hashCode.Add(CreatedTimestamp);
            hashCode.Add(LastUpdatedTimestamp);
            return hashCode.ToHashCode();
        }
    }
}
