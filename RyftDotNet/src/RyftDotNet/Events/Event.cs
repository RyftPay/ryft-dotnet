using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Common;
using RyftDotNet.Utility;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Events
{
    [JsonConverter(typeof(EventJsonConverter))]
    public sealed class Event : IEquatable<Event>
    {
        public string Id { get; }

        public EventType EventType { get; }

        public EventData Data { get; }

        public IEnumerable<EventEndpoint> Endpoints { get; }

        public string? AccountId { get; }

        public DateTimeOffset CreatedTimestamp { get; }

        public Event(
            string id,
            EventType eventType,
            EventData data,
            IEnumerable<EventEndpoint> endpoints,
            string? accountId,
            DateTimeOffset createdTimestamp)
        {
            Id = id;
            EventType = eventType;
            Data = data;
            Endpoints = endpoints;
            AccountId = accountId;
            CreatedTimestamp = createdTimestamp;
        }

        public bool Equals(Event? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && EventType == other.EventType
                   && Equals(Data, other.Data)
                   && Utilities.SequenceEqual(Endpoints, other.Endpoints)
                   && AccountId == other.AccountId
                   && Equals(CreatedTimestamp, other.CreatedTimestamp));

        public override bool Equals(object? obj)
            => obj is Event other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                Id,
                EventType,
                Data,
                Endpoints,
                AccountId,
                CreatedTimestamp
            ).GetHashCode();
    }
}
