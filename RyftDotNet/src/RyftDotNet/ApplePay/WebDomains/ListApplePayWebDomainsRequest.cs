using RyftDotNet.Utility;

namespace RyftDotNet.ApplePay.WebDomains
{
    public sealed class ListApplePayWebDomainsRequest
    {
        public bool? Ascending { get; set; }
        public int? Limit { get; set; }
        public string? StartsAfter { get; set; }

        private const string AscendingQueryString = "ascending";
        private const string LimitQueryString = "limit";
        private const string StartsAfterQueryString = "startsAfter";

        internal string ToQueryString() => QueryParameterUtility.BuildQueryString(
            (AscendingQueryString, Ascending?.ToString().ToLower()),
            (LimitQueryString, Limit?.ToString()),
            (StartsAfterQueryString, StartsAfter)
        );
    }
}
