using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Subscriptions
{
    public sealed class SubscriptionPaymentMethod : IEquatable<SubscriptionPaymentMethod>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        public SubscriptionPaymentMethod(string id)
        {
            Id = id;
        }

        public bool Equals(SubscriptionPaymentMethod? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id);

        public override bool Equals(object? obj)
            => obj is SubscriptionPaymentMethod other && Equals(other);

        public override int GetHashCode() => Id.GetHashCode();
    }
}
