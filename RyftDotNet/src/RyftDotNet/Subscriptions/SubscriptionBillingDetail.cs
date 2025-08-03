using System;
using System.Text.Json.Serialization;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Subscriptions
{
    public sealed class SubscriptionBillingDetail : IEquatable<SubscriptionBillingDetail>
    {
        [property: JsonPropertyName("totalCycles")]
        public int TotalCycles { get; }

        [property: JsonPropertyName("currentCycle")]
        public int CurrentCycle { get; }

        [property: JsonPropertyName("currentCycleStartTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CurrentCycleStartTimestamp { get; }

        [property: JsonPropertyName("currentCycleEndTimestamp"),
                   JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CurrentCycleEndTimestamp { get; }

        [property: JsonPropertyName("billingCycleTimestamp"),
                   JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset BillingCycleTimestamp { get; }

        [property: JsonPropertyName("nextBillingTimestamp"),
                   JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset? NextBillingTimestamp { get; }

        [property: JsonPropertyName("failureDetail")]
        public SubscriptionBillingFailureDetail? FailureDetail { get; }

        public SubscriptionBillingDetail(
            int totalCycles,
            int currentCycle,
            DateTimeOffset currentCycleStartTimestamp,
            DateTimeOffset currentCycleEndTimestamp,
            DateTimeOffset billingCycleTimestamp,
            DateTimeOffset? nextBillingTimestamp = null,
            SubscriptionBillingFailureDetail? failureDetail = null)
        {
            TotalCycles = totalCycles;
            CurrentCycle = currentCycle;
            CurrentCycleStartTimestamp = currentCycleStartTimestamp;
            CurrentCycleEndTimestamp = currentCycleEndTimestamp;
            BillingCycleTimestamp = billingCycleTimestamp;
            NextBillingTimestamp = nextBillingTimestamp;
            FailureDetail = failureDetail;
        }

        public bool Equals(SubscriptionBillingDetail? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || TotalCycles == other.TotalCycles
                   && CurrentCycle == other.CurrentCycle
                   && CurrentCycleStartTimestamp.Equals(other.CurrentCycleStartTimestamp)
                   && CurrentCycleEndTimestamp.Equals(other.CurrentCycleEndTimestamp)
                   && BillingCycleTimestamp.Equals(other.BillingCycleTimestamp)
                   && Nullable.Equals(NextBillingTimestamp, other.NextBillingTimestamp)
                   && Equals(FailureDetail, other.FailureDetail));

        public override bool Equals(object? obj)
            => obj is SubscriptionBillingDetail other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                TotalCycles,
                CurrentCycle,
                CurrentCycleStartTimestamp,
                CurrentCycleEndTimestamp,
                BillingCycleTimestamp,
                NextBillingTimestamp,
                FailureDetail
            );
    }
}
