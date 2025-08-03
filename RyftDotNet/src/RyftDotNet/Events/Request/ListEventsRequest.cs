using RyftDotNet.Utility;

namespace RyftDotNet.Events.Request
{
    public sealed class ListEventsRequest
    {
        public bool? Ascending { get; set; }
        public int? Limit { get; set; }

        private const string AscendingQueryString = "ascending";
        private const string LimitQueryString = "limit";

        internal string ToQueryString() => QueryParameterUtility.BuildQueryString(
            (AscendingQueryString, Ascending?.ToString().ToLower()),
            (LimitQueryString, Limit?.ToString())
        );
    }
}
