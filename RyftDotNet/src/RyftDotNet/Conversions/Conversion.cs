using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Conversions
{
    public sealed class Conversion : IEquatable<Conversion>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("sell")]
        public ConversionSell Sell { get; }

        [property: JsonPropertyName("buy")]
        public ConversionBuy Buy { get; }

        [property: JsonPropertyName("rate")]
        public decimal? Rate { get; }

        [property: JsonPropertyName("status")]
        public ConversionStatus Status { get; }

        [property: JsonPropertyName("reason")]
        public string? Reason { get; }

        [property: JsonPropertyName("estimatedSettlementDate")]
        public string? EstimatedSettlementDate { get; }

        [property: JsonPropertyName("settledTimestamp")]
        public long? SettledTimestamp { get; }

        [property: JsonPropertyName("createdBy")]
        public ConversionCreatedBy? CreatedBy { get; }

        [property: JsonPropertyName("createdTimestamp")]
        public long CreatedTimestamp { get; }

        public Conversion(
            string id,
            ConversionSell sell,
            ConversionBuy buy,
            decimal? rate,
            ConversionStatus status,
            string? reason,
            string? estimatedSettlementDate,
            long? settledTimestamp,
            ConversionCreatedBy? createdBy,
            long createdTimestamp)
        {
            Id = id;
            Sell = sell;
            Buy = buy;
            Rate = rate;
            Status = status;
            Reason = reason;
            EstimatedSettlementDate = estimatedSettlementDate;
            SettledTimestamp = settledTimestamp;
            CreatedBy = createdBy;
            CreatedTimestamp = createdTimestamp;
        }

        public bool Equals(Conversion? other) =>
            !(other is null) && (ReferenceEquals(this, other) || Id == other.Id
                && Sell.Equals(other.Sell)
                && Buy.Equals(other.Buy)
                && Rate == other.Rate
                && Status == other.Status
                && Reason == other.Reason
                && EstimatedSettlementDate == other.EstimatedSettlementDate
                && SettledTimestamp == other.SettledTimestamp
                && Equals(CreatedBy, other.CreatedBy)
                && CreatedTimestamp == other.CreatedTimestamp);

        public override bool Equals(object? obj) =>
            ReferenceEquals(this, obj) || obj is Conversion other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Sell);
            hashCode.Add(Buy);
            hashCode.Add(Rate);
            hashCode.Add(Status);
            hashCode.Add(Reason);
            hashCode.Add(EstimatedSettlementDate);
            hashCode.Add(SettledTimestamp);
            hashCode.Add(CreatedBy);
            hashCode.Add(CreatedTimestamp);
            return hashCode.ToHashCode();
        }
    }
}
