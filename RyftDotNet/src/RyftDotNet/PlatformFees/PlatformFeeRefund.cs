using System;
using System.Text.Json.Serialization;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.PlatformFees
{
    public sealed class PlatformFeeRefund : IEquatable<PlatformFeeRefund>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("platformFeeId")]
        public string PlatformFeeId { get; }

        [property: JsonPropertyName("amount")]
        public int Amount { get; }

        [property: JsonPropertyName("currency")]
        public string Currency { get; }

        [property: JsonPropertyName("reason")]
        public string? Reason { get; }

        [property: JsonPropertyName("status")]
        public string Status { get; }

        [property:
            JsonPropertyName("createdTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CreatedTimestamp { get; }

        [property:
            JsonPropertyName("lastUpdatedTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset LastUpdatedTimestamp { get; }

        public PlatformFeeRefund(
            string id,
            string platformFeeId,
            int amount,
            string currency,
            string? reason,
            string status,
            DateTimeOffset createdTimestamp,
            DateTimeOffset lastUpdatedTimestamp)
        {
            Id = id;
            PlatformFeeId = platformFeeId;
            Amount = amount;
            Currency = currency;
            Reason = reason;
            Status = status;
            CreatedTimestamp = createdTimestamp;
            LastUpdatedTimestamp = lastUpdatedTimestamp;
        }

        public bool Equals(PlatformFeeRefund? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && PlatformFeeId == other.PlatformFeeId
                   && Amount == other.Amount
                   && Currency == other.Currency
                   && Reason == other.Reason
                   && Status == other.Status
                   && CreatedTimestamp.ToUnixTimeSeconds() == other.CreatedTimestamp.ToUnixTimeSeconds()
                   && LastUpdatedTimestamp.ToUnixTimeSeconds() == other.LastUpdatedTimestamp.ToUnixTimeSeconds());

        public override bool Equals(object? obj)
            => obj is PlatformFeeRefund other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                Id,
                PlatformFeeId,
                Amount,
                Currency,
                Reason,
                Status,
                CreatedTimestamp,
                LastUpdatedTimestamp
            ).GetHashCode();
    }
}
