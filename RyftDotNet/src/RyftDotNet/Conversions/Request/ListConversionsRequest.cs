using RyftDotNet.Utility;

namespace RyftDotNet.Conversions.Request
{
    public sealed class ListConversionsRequest
    {
        public int? Limit { get; set; }
        public bool? Ascending { get; set; }
        public string? StartsAfter { get; set; }
        public long? StartTimestamp { get; set; }
        public long? EndTimestamp { get; set; }

        private const string StartTimestampQueryString = "startTimestamp";
        private const string EndTimestampQueryString = "endTimestamp";
        private const string LimitQueryString = "limit";
        private const string AscendingQueryString = "ascending";
        private const string PaginationTokenQueryString = "startsAfter";

        internal string ToQueryString() => QueryParameterUtility.BuildQueryString(
            (StartTimestampQueryString, StartTimestamp?.ToString()),
            (EndTimestampQueryString, EndTimestamp?.ToString()),
            (LimitQueryString, Limit?.ToString()),
            (AscendingQueryString, Ascending?.ToString().ToLower()),
            (PaginationTokenQueryString, StartsAfter)
        );
    }
}
