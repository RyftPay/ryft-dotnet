using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions
{
    public sealed class SplitPaymentItemFee : IEquatable<SplitPaymentItemFee>
    {
        [property: JsonPropertyName("amount")]
        public long Amount { get; }

        public SplitPaymentItemFee(long amount)
        {
            Amount = amount;
        }

        public bool Equals(SplitPaymentItemFee? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Amount == other.Amount);

        public override bool Equals(object? obj)
            => obj is SplitPaymentItemFee other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Amount).GetHashCode();
    }
}
