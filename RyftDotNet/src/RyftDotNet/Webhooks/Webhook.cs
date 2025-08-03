using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Common;
using RyftDotNet.Utility;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Webhooks
{
    public sealed class Webhook : IEquatable<Webhook>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("active")]
        public bool Active { get; }

        [property: JsonPropertyName("url")]
        public string Url { get; }

        [property: JsonPropertyName("eventTypes")]
        public IEnumerable<EventType> EventTypes { get; }

        [property:
            JsonPropertyName("createdTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CreatedTimestamp { get; }

        [property:
            JsonPropertyName("lastUpdatedTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset LastUpdatedTimestamp { get; }

        public Webhook(
            string id,
            bool active,
            string url,
            IEnumerable<EventType> eventTypes,
            DateTimeOffset createdTimestamp,
            DateTimeOffset lastUpdatedTimestamp)
        {
            Id = id;
            Active = active;
            Url = url;
            EventTypes = eventTypes;
            CreatedTimestamp = createdTimestamp;
            LastUpdatedTimestamp = lastUpdatedTimestamp;
        }

        public bool Equals(Webhook? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && Active == other.Active
                   && Url == other.Url
                   && Utilities.SequenceEqual(EventTypes, other.EventTypes)
                   && CreatedTimestamp.ToUnixTimeSeconds() == other.CreatedTimestamp.ToUnixTimeSeconds()
                   && LastUpdatedTimestamp.ToUnixTimeSeconds() == other.LastUpdatedTimestamp.ToUnixTimeSeconds());

        public override bool Equals(object? obj)
            => obj is Webhook other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                Id,
                Active,
                Url,
                EventTypes,
                CreatedTimestamp,
                LastUpdatedTimestamp
            ).GetHashCode();
    }
}
