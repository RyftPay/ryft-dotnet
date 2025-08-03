using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Balances
{
    public sealed class BalanceAmount : IEquatable<BalanceAmount>
    {
        [property: JsonPropertyName("amount")]
        public long Amount { get; }

        public BalanceAmount(long amount)
        {
            Amount = amount;
        }

        public bool Equals(BalanceAmount? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Amount == other.Amount);

        public override bool Equals(object? obj)
            => obj is BalanceAmount other && Equals(other);

        public override int GetHashCode() => Amount.GetHashCode();
    }
}
