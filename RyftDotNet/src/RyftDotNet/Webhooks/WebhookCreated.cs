using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Common;
using RyftDotNet.Utility;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Webhooks
{
    public sealed class WebhookCreated : IEquatable<WebhookCreated>
    {
        [property: JsonPropertyName("secret")]
        public string Secret { get; }

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

        public WebhookCreated(
            string secret,
            string id,
            bool active,
            string url,
            IEnumerable<EventType> eventTypes,
            DateTimeOffset createdTimestamp)
        {
            Secret = secret;
            Id = id;
            Active = active;
            Url = url;
            EventTypes = eventTypes;
            CreatedTimestamp = createdTimestamp;
        }

        public bool Equals(WebhookCreated? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Secret == other.Secret
                   && Id == other.Id
                   && Active == other.Active
                   && Url == other.Url
                   && Utilities.SequenceEqual(EventTypes, other.EventTypes)
                   && CreatedTimestamp.ToUnixTimeSeconds() == other.CreatedTimestamp.ToUnixTimeSeconds());

        public override bool Equals(object? obj)
            => obj is WebhookCreated other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                Secret,
                Id,
                Active,
                Url,
                EventTypes,
                CreatedTimestamp
            ).GetHashCode();
    }
}
