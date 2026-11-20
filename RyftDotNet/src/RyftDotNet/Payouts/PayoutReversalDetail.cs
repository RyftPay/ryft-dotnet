using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Payouts
{
    public sealed class PayoutReversalDetail : IEquatable<PayoutReversalDetail>
    {
        [property: JsonPropertyName("payoutReversed")]
        public bool PayoutReversed { get; }

        [property: JsonPropertyName("feeReversed")]
        public bool? FeeReversed { get; }

        public PayoutReversalDetail(bool payoutReversed, bool? feeReversed = null)
        {
            PayoutReversed = payoutReversed;
            FeeReversed = feeReversed;
        }

        public bool Equals(PayoutReversalDetail? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || PayoutReversed == other.PayoutReversed &&
                   FeeReversed == other.FeeReversed);

        public override bool Equals(object? obj)
            => obj is PayoutReversalDetail other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(PayoutReversed, FeeReversed);
    }
}
