using System;
using RyftDotNet.Utility;

namespace RyftDotNet.Subscriptions.Request
{
    public sealed class ListSubscriptionsRequest
    {
        public bool? Ascending { get; set; }
        public int? Limit { get; set; }
        public string? StartsAfter { get; set; }
        public DateTimeOffset? StartTimestamp { get; set; }
        public DateTimeOffset? EndTimestamp { get; set; }

        private const string AscendingQueryString = "ascending";
        private const string LimitQueryString = "limit";
        private const string StartsAfterQueryString = "startsAfter";
        private const string StartTimestampQueryString = "startTimestamp";
        private const string EndTimestampQueryString = "endTimestamp";

        internal string ToQueryString() => QueryParameterUtility.BuildQueryString(
            (AscendingQueryString, Ascending?.ToString().ToLower()),
            (LimitQueryString, Limit?.ToString()),
            (StartsAfterQueryString, StartsAfter),
            (StartTimestampQueryString, StartTimestamp?.ToUnixTimeSeconds().ToString()),
            (EndTimestampQueryString, EndTimestamp?.ToUnixTimeSeconds().ToString())
        );
    }
}
