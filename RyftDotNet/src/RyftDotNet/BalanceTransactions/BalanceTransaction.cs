using System;
using System.Text.Json.Serialization;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.BalanceTransactions
{
    public sealed class BalanceTransaction : IEquatable<BalanceTransaction>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("type")]
        public BalanceTransactionType Type { get; }

        [property: JsonPropertyName("amount")]
        public long Amount { get; }

        [property: JsonPropertyName("currency")]
        public string Currency { get; }

        [property: JsonPropertyName("status")]
        public BalanceTransactionStatus Status { get; }

        [property: JsonPropertyName("origin")]
        public BalanceTransactionOrigin Origin { get; }

        [property:
            JsonPropertyName("availableAt"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset AvailableAt { get; }

        [property:
            JsonPropertyName("createdTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CreatedTimestamp { get; }

        [property:
            JsonPropertyName("lastUpdatedTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset LastUpdatedTimestamp { get; }

        [property: JsonPropertyName("description")]
        public string? Description { get; }

        [property: JsonPropertyName("feeTotal")]
        public long? FeeTotal { get; }

        [property: JsonPropertyName("net")]
        public long? Net { get; }

        public BalanceTransaction(
            string id,
            BalanceTransactionType type,
            long amount,
            string currency,
            BalanceTransactionStatus status,
            BalanceTransactionOrigin origin,
            DateTimeOffset availableAt,
            DateTimeOffset createdTimestamp,
            DateTimeOffset lastUpdatedTimestamp,
            string? description = null,
            long? feeTotal = null,
            long? net = null)
        {
            Id = id;
            Type = type;
            Amount = amount;
            Currency = currency;
            Status = status;
            Origin = origin;
            AvailableAt = availableAt;
            CreatedTimestamp = createdTimestamp;
            LastUpdatedTimestamp = lastUpdatedTimestamp;
            Description = description;
            FeeTotal = feeTotal;
            Net = net;
        }

        public bool Equals(BalanceTransaction? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && Type == other.Type
                   && Amount == other.Amount
                   && Currency == other.Currency
                   && Status == other.Status
                   && Origin.Equals(other.Origin)
                   && AvailableAt.Equals(other.AvailableAt)
                   && CreatedTimestamp.Equals(other.CreatedTimestamp)
                   && LastUpdatedTimestamp.Equals(other.LastUpdatedTimestamp)
                   && Description == other.Description
                   && FeeTotal == other.FeeTotal
                   && Net == other.Net);

        public override bool Equals(object? obj)
            => obj is BalanceTransaction other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Type);
            hashCode.Add(Amount);
            hashCode.Add(Currency);
            hashCode.Add(Status);
            hashCode.Add(Origin);
            hashCode.Add(AvailableAt);
            hashCode.Add(CreatedTimestamp);
            hashCode.Add(LastUpdatedTimestamp);
            hashCode.Add(Description);
            hashCode.Add(FeeTotal);
            hashCode.Add(Net);
            return hashCode.ToHashCode();
        }
    }
}
