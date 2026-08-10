using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Conversions
{
    public sealed class ConversionFee : IEquatable<ConversionFee>
    {
        [property: JsonPropertyName("amount")]
        public long Amount { get; }

        public ConversionFee(long amount)
        {
            Amount = amount;
        }

        public bool Equals(ConversionFee? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Amount == other.Amount);

        public override bool Equals(object? obj)
            => obj is ConversionFee other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Amount);
    }
}
