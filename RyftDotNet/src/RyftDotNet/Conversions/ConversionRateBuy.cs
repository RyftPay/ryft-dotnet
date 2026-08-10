using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Conversions
{
    public sealed class ConversionRateBuy : IEquatable<ConversionRateBuy>
    {
        [property: JsonPropertyName("amount")]
        public long Amount { get; }

        [property: JsonPropertyName("currency")]
        public string Currency { get; }

        [property: JsonPropertyName("fees")]
        public ConversionFees? Fees { get; }

        public ConversionRateBuy(long amount, string currency, ConversionFees? fees)
        {
            Amount = amount;
            Currency = currency;
            Fees = fees;
        }

        public bool Equals(ConversionRateBuy? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Amount == other.Amount
                   && Currency == other.Currency
                   && Equals(Fees, other.Fees));

        public override bool Equals(object? obj)
            => obj is ConversionRateBuy other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Amount, Currency, Fees);
    }
}
