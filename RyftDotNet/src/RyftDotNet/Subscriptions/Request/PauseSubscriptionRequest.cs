using System;
using System.Text.Json.Serialization;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Subscriptions.Request
{
    public sealed class PauseSubscriptionRequest
    {
        [property: JsonPropertyName("reason")]
        public string? Reason { get; set; }

        [property: JsonPropertyName("resumeAtTimestamp"),
                   JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset? ResumeAtTimestamp { get; set; }

        [property: JsonPropertyName("unschedule")]
        public bool? Unschedule { get; set; }
    }
}
