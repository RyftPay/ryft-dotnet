using System;
using RyftDotNet.Utility;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class ListPaymentSessionsRequest
    {
        public DateTimeOffset? StartTimestamp { get; set; }
        public DateTimeOffset? EndTimestamp { get; set; }
        public bool? Ascending { get; set; }
        public int? Limit { get; set; }
        public string? StartsAfter { get; set; }

        private const string StartTimestampQueryString = "startTimestamp";
        private const string EndTimestampQueryString = "endTimestamp";
        private const string AscendingQueryString = "ascending";
        private const string LimitQueryString = "limit";
        private const string StartsAfterQueryString = "startsAfter";

        internal string ToQueryString() => QueryParameterUtility.BuildQueryString(
            (StartTimestampQueryString, StartTimestamp?.ToUnixTimeSeconds().ToString()),
            (EndTimestampQueryString, EndTimestamp?.ToUnixTimeSeconds().ToString()),
            (AscendingQueryString, Ascending?.ToString().ToLower()),
            (LimitQueryString, Limit?.ToString()),
            (StartsAfterQueryString, StartsAfter)
        );
    }
}
