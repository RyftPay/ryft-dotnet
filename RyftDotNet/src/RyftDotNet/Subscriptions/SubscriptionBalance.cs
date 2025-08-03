using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Subscriptions
{
    public sealed class SubscriptionBalance : IEquatable<SubscriptionBalance>
    {
        [property: JsonPropertyName("amount")]
        public long Amount { get; }

        public SubscriptionBalance(long amount)
        {
            Amount = amount;
        }

        public bool Equals(SubscriptionBalance? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Amount == other.Amount);

        public override bool Equals(object? obj)
            => obj is SubscriptionBalance other && Equals(other);

        public override int GetHashCode() => Amount.GetHashCode();
    }
}
