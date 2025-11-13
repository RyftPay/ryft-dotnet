using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Utility;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.InPerson.Locations
{
    public sealed class InPersonLocation : IEquatable<InPersonLocation>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("name")]
        public string Name { get; }

        [property: JsonPropertyName("address")]
        public InPersonLocationAddress Address { get; }

        [property: JsonPropertyName("geoCoordinates")]
        public GeoCoordinates? GeoCoordinates { get; }

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

        public InPersonLocation(
            string id,
            string name,
            InPersonLocationAddress address,
            DateTimeOffset createdTimestamp,
            DateTimeOffset lastUpdatedTimestamp,
            GeoCoordinates? geoCoordinates = null,
            IDictionary<string, string>? metadata = null)
        {
            Id = id;
            Name = name;
            Address = address;
            CreatedTimestamp = createdTimestamp;
            LastUpdatedTimestamp = lastUpdatedTimestamp;
            GeoCoordinates = geoCoordinates;
            Metadata = metadata;
        }

        public bool Equals(InPersonLocation? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && Name == other.Name
                   && Address.Equals(other.Address)
                   && Equals(GeoCoordinates, other.GeoCoordinates)
                   && Utilities.DictionaryEquals(Metadata, other.Metadata)
                   && CreatedTimestamp.Equals(other.CreatedTimestamp)
                   && LastUpdatedTimestamp.Equals(other.LastUpdatedTimestamp));

        public override bool Equals(object? obj)
            => obj is InPersonLocation other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Name);
            hashCode.Add(Address);
            hashCode.Add(GeoCoordinates);
            hashCode.Add(Metadata);
            hashCode.Add(CreatedTimestamp);
            hashCode.Add(LastUpdatedTimestamp);
            return hashCode.ToHashCode();
        }
    }
}
