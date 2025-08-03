using RyftDotNet.Utility;

namespace RyftDotNet.Files.Request
{
    public sealed class ListFilesRequest
    {
        public FileCategory? Category { get; set; }
        public bool? Ascending { get; set; }
        public int? Limit { get; set; }
        public string? StartsAfter { get; set; }

        private const string CategoryQueryString = "category";
        private const string AscendingQueryString = "ascending";
        private const string LimitQueryString = "limit";
        private const string StartsAfterQueryString = "startsAfter";

        internal string ToQueryString() => QueryParameterUtility.BuildQueryString(
            (CategoryQueryString, Category?.Value),
            (AscendingQueryString, Ascending?.ToString().ToLower()),
            (LimitQueryString, Limit?.ToString()),
            (StartsAfterQueryString, StartsAfter)
        );
    }
}
