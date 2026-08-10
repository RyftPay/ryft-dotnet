using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Conversions
{
    public sealed class ConversionFees : IEquatable<ConversionFees>
    {
        [property: JsonPropertyName("ryft")]
        public ConversionFee? Ryft { get; }

        [property: JsonPropertyName("platform")]
        public ConversionPlatformFeeDetail? Platform { get; }

        public ConversionFees(ConversionFee? ryft, ConversionPlatformFeeDetail? platform)
        {
            Ryft = ryft;
            Platform = platform;
        }

        public bool Equals(ConversionFees? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Equals(Ryft, other.Ryft)
                   && Equals(Platform, other.Platform));

        public override bool Equals(object? obj)
            => obj is ConversionFees other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Ryft, Platform);
    }
}
