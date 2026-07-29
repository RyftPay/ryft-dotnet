using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Conversions
{
    public sealed class ConversionPlatformFeeDetail : IEquatable<ConversionPlatformFeeDetail>
    {
        [property: JsonPropertyName("amount")]
        public long Amount { get; }

        [property: JsonPropertyName("ryftFee")]
        public ConversionFee RyftFee { get; }

        public ConversionPlatformFeeDetail(long amount, ConversionFee ryftFee)
        {
            Amount = amount;
            RyftFee = ryftFee;
        }

        public bool Equals(ConversionPlatformFeeDetail? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Amount == other.Amount
                   && Equals(RyftFee, other.RyftFee));

        public override bool Equals(object? obj)
            => obj is ConversionPlatformFeeDetail other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Amount, RyftFee);
    }
}
