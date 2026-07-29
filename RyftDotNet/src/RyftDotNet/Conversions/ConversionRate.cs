using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Conversions
{
    public sealed class ConversionRate : IEquatable<ConversionRate>
    {
        [property: JsonPropertyName("sell")]
        public ConversionRateSell Sell { get; }

        [property: JsonPropertyName("buy")]
        public ConversionRateBuy Buy { get; }

        [property: JsonPropertyName("rate")]
        public decimal Rate { get; }

        [property: JsonPropertyName("estimatedSettlementDate")]
        public string? EstimatedSettlementDate { get; }

        public ConversionRate(
            ConversionRateSell sell,
            ConversionRateBuy buy,
            decimal rate,
            string? estimatedSettlementDate)
        {
            Sell = sell;
            Buy = buy;
            Rate = rate;
            EstimatedSettlementDate = estimatedSettlementDate;
        }

        public bool Equals(ConversionRate? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Sell.Equals(other.Sell)
                   && Buy.Equals(other.Buy)
                   && Rate == other.Rate
                   && EstimatedSettlementDate == other.EstimatedSettlementDate);

        public override bool Equals(object? obj)
            => obj is ConversionRate other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Sell, Buy, Rate, EstimatedSettlementDate);
    }
}
