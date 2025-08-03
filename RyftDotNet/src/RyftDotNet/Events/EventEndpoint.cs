using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Events
{
    public sealed class EventEndpoint : IEquatable<EventEndpoint>
    {
        [property: JsonPropertyName("webhookId")]
        public string WebhookId { get; }

        [property: JsonPropertyName("acknowledged")]
        public bool Acknowledged { get; }

        [property: JsonPropertyName("attempts")]
        public int Attempts { get; }

        public EventEndpoint(string webhookId, bool acknowledged, int attempts)
        {
            WebhookId = webhookId;
            Acknowledged = acknowledged;
            Attempts = attempts;
        }

        public bool Equals(EventEndpoint? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || WebhookId == other.WebhookId
                   && Acknowledged == other.Acknowledged
                   && Attempts == other.Attempts);

        public override bool Equals(object? obj)
            => obj is EventEndpoint other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(WebhookId, Acknowledged, Attempts);
    }
}
