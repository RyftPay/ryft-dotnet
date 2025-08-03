using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Subscriptions
{
    public sealed class SubscriptionPaymentSessions : IEquatable<SubscriptionPaymentSessions>
    {
        [property: JsonPropertyName("initial")]
        public SubscriptionPaymentSession Initial { get; }

        [property: JsonPropertyName("latest")]
        public SubscriptionPaymentSession Latest { get; }

        public SubscriptionPaymentSessions(SubscriptionPaymentSession initial, SubscriptionPaymentSession latest)
        {
            Initial = initial;
            Latest = latest;
        }

        public bool Equals(SubscriptionPaymentSessions? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Initial.Equals(other.Initial)
                   && Latest.Equals(other.Latest));

        public override bool Equals(object? obj)
            => obj is SubscriptionPaymentSessions other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Initial, Latest);
    }
}
