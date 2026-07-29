using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Conversions
{
    public sealed class ConversionRateSell : IEquatable<ConversionRateSell>
    {
        [property: JsonPropertyName("amount")]
        public long Amount { get; }

        [property: JsonPropertyName("currency")]
        public string Currency { get; }

        public ConversionRateSell(long amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public bool Equals(ConversionRateSell? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Amount == other.Amount
                   && Currency == other.Currency);

        public override bool Equals(object? obj)
            => obj is ConversionRateSell other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Amount, Currency);
    }
}
