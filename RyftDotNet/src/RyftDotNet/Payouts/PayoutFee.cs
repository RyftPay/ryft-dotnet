using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Payouts
{
    public sealed class PayoutFee : IEquatable<PayoutFee>
    {
        [property: JsonPropertyName("amount")]
        public long Amount { get; }

        public PayoutFee(long amount)
        {
            Amount = amount;
        }

        public bool Equals(PayoutFee? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Amount == other.Amount);

        public override bool Equals(object? obj)
            => obj is PayoutFee other && Equals(other);

        public override int GetHashCode()
            => Amount.GetHashCode();
    }
}
