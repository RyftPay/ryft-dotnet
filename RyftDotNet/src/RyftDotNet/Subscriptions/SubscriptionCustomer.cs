using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Subscriptions
{
    public sealed class SubscriptionCustomer : IEquatable<SubscriptionCustomer>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        public SubscriptionCustomer(string id)
        {
            Id = id;
        }

        public bool Equals(SubscriptionCustomer? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id);

        public override bool Equals(object? obj)
            => obj is SubscriptionCustomer other && Equals(other);

        public override int GetHashCode() => Id.GetHashCode();
    }
}
