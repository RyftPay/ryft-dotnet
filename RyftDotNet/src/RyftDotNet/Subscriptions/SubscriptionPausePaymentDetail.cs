using System;
using System.Text.Json.Serialization;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Subscriptions
{
    public sealed class SubscriptionPausePaymentDetail : IEquatable<SubscriptionPausePaymentDetail>
    {
        [property: JsonPropertyName("pausedAtTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset PausedAtTimestamp { get; }

        [property: JsonPropertyName("reason")]
        public string? Reason { get; }

        [property: JsonPropertyName("resumeAtTimestamp"),
                   JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset? ResumeAtTimestamp { get; }

        public SubscriptionPausePaymentDetail(
            DateTimeOffset pausedAtTimestamp,
            string? reason = null,
            DateTimeOffset? resumeAtTimestamp = null)
        {
            PausedAtTimestamp = pausedAtTimestamp;
            Reason = reason;
            ResumeAtTimestamp = resumeAtTimestamp;
        }

        public bool Equals(SubscriptionPausePaymentDetail? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || PausedAtTimestamp.Equals(other.PausedAtTimestamp)
                   && Reason == other.Reason
                   && Nullable.Equals(ResumeAtTimestamp, other.ResumeAtTimestamp));

        public override bool Equals(object? obj)
            => obj is SubscriptionPausePaymentDetail other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(PausedAtTimestamp, Reason, ResumeAtTimestamp);
    }
}
