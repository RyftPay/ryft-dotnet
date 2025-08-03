using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Subscriptions
{
    public sealed class SubscriptionInterval : IEquatable<SubscriptionInterval>
    {
        [property: JsonPropertyName("unit")]
        public IntervalUnit Unit { get; }

        [property: JsonPropertyName("count")]
        public int Count { get; }

        [property: JsonPropertyName("times")]
        public int? Times { get; }

        public SubscriptionInterval(
            IntervalUnit unit,
            int count,
            int? times = null)
        {
            Unit = unit;
            Count = count;
            Times = times;
        }

        public bool Equals(SubscriptionInterval? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Unit.Equals(other.Unit)
                   && Count == other.Count
                   && Times == other.Times);

        public override bool Equals(object? obj)
            => obj is SubscriptionInterval other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Unit);
            hashCode.Add(Count);
            hashCode.Add(Times);
            return hashCode.ToHashCode();
        }
    }
}
