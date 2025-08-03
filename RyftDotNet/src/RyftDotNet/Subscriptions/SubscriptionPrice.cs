using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Subscriptions
{
    public sealed class SubscriptionPrice : IEquatable<SubscriptionPrice>
    {
        [property: JsonPropertyName("amount")]
        public long Amount { get; }

        [property: JsonPropertyName("currency")]
        public string Currency { get; }

        [property: JsonPropertyName("interval")]
        public SubscriptionInterval Interval { get; }

        public SubscriptionPrice(long amount, string currency, SubscriptionInterval interval)
        {
            Amount = amount;
            Currency = currency;
            Interval = interval;
        }

        public bool Equals(SubscriptionPrice? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Amount == other.Amount
                   && Currency == other.Currency
                   && Interval.Equals(other.Interval));

        public override bool Equals(object? obj)
            => obj is SubscriptionPrice other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Amount, Currency, Interval);
    }
}
