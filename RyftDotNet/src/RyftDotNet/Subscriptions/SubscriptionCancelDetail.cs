using System;
using System.Text.Json.Serialization;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Subscriptions
{
    public sealed class SubscriptionCancelDetail : IEquatable<SubscriptionCancelDetail>
    {
        [property: JsonPropertyName("cancelledAtTimestamp"),
                   JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CancelledAtTimestamp { get; }

        [property: JsonPropertyName("reason")]
        public string? Reason { get; }

        public SubscriptionCancelDetail(DateTimeOffset cancelledAtTimestamp, string? reason = null)
        {
            CancelledAtTimestamp = cancelledAtTimestamp;
            Reason = reason;
        }

        public bool Equals(SubscriptionCancelDetail? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || CancelledAtTimestamp.Equals(other.CancelledAtTimestamp)
                   && Reason == other.Reason);

        public override bool Equals(object? obj)
            => obj is SubscriptionCancelDetail other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(CancelledAtTimestamp, Reason);
    }
}
