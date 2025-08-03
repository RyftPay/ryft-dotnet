using System;
using System.Text.Json.Serialization;
using RyftDotNet.Common;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Payouts
{
    public sealed class Payout : IEquatable<Payout>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("amount")]
        public long Amount { get; }

        [property: JsonPropertyName("currency")]
        public string Currency { get; }

        [property: JsonPropertyName("status")]
        public PayoutStatus Status { get; }

        [property: JsonPropertyName("scheduleType")]
        public PayoutScheduleType ScheduleType { get; }

        [property:
            JsonPropertyName("createdTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CreatedTimestamp { get; }

        [property:
            JsonPropertyName("scheduledTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset ScheduledTimestamp { get; }

        [property:
            JsonPropertyName("completedTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset? CompletedTimestamp { get; }

        [property: JsonPropertyName("payoutMethod")]
        public PayoutPayoutMethod? PayoutMethod { get; }

        [property: JsonPropertyName("failureReason")]
        public string? FailureReason { get; }

        [property: JsonPropertyName("scheme")]
        public PayoutScheme? Scheme { get; }

        public Payout(
            string id,
            long amount,
            string currency,
            PayoutStatus status,
            PayoutScheduleType scheduleType,
            DateTimeOffset createdTimestamp,
            DateTimeOffset scheduledTimestamp,
            DateTimeOffset? completedTimestamp = null,
            PayoutPayoutMethod? payoutMethod = null,
            string? failureReason = null,
            PayoutScheme? scheme = null)
        {
            Id = id;
            Amount = amount;
            Currency = currency;
            Status = status;
            ScheduleType = scheduleType;
            CreatedTimestamp = createdTimestamp;
            ScheduledTimestamp = scheduledTimestamp;
            CompletedTimestamp = completedTimestamp;
            PayoutMethod = payoutMethod;
            FailureReason = failureReason;
            Scheme = scheme;
        }

        public bool Equals(Payout? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id &&
                   Amount == other.Amount
                   && Currency == other.Currency
                   && Status == other.Status
                   && ScheduleType == other.ScheduleType
                   && CreatedTimestamp.Equals(other.CreatedTimestamp)
                   && ScheduledTimestamp.Equals(other.ScheduledTimestamp)
                   && CompletedTimestamp.Equals(other.CompletedTimestamp)
                   && Equals(PayoutMethod, other.PayoutMethod)
                   && FailureReason == other.FailureReason
                   && Scheme == other.Scheme);

        public override bool Equals(object? obj)
            => obj is Payout other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Amount);
            hashCode.Add(Currency);
            hashCode.Add(Status);
            hashCode.Add(ScheduleType);
            hashCode.Add(CreatedTimestamp);
            hashCode.Add(ScheduledTimestamp);
            hashCode.Add(CompletedTimestamp);
            hashCode.Add(PayoutMethod);
            hashCode.Add(FailureReason);
            hashCode.Add(Scheme);
            return hashCode.ToHashCode();
        }
    }
}
