using System;
using System.Text.Json.Serialization;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Balances
{
    public sealed class Balance : IEquatable<Balance>
    {
        [property: JsonPropertyName("currency")]
        public string Currency { get; }

        [property: JsonPropertyName("pending")]
        public BalanceAmount Pending { get; }

        [property: JsonPropertyName("cleared")]
        public BalanceAmount Cleared { get; }

        [property: JsonPropertyName("available")]
        public BalanceAmount Available { get; }

        [property:
            JsonPropertyName("lastUpdatedTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset? LastUpdatedTimestamp { get; }

        public Balance(
            string currency,
            BalanceAmount pending,
            BalanceAmount cleared,
            BalanceAmount available,
            DateTimeOffset? lastUpdatedTimestamp = null)
        {
            Currency = currency;
            Pending = pending;
            Cleared = cleared;
            Available = available;
            LastUpdatedTimestamp = lastUpdatedTimestamp;
        }

        public bool Equals(Balance? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Currency == other.Currency
                   && Pending.Equals(other.Pending)
                   && Cleared.Equals(other.Cleared)
                   && Available.Equals(other.Available)
                   && Nullable.Equals(LastUpdatedTimestamp, other.LastUpdatedTimestamp));

        public override bool Equals(object? obj)
            => obj is Balance other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                Currency,
                Pending,
                Cleared,
                Available,
                LastUpdatedTimestamp
            );
    }
}
