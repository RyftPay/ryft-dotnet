using RyftDotNet.Utility;

namespace RyftDotNet.BalanceTransactions.Request
{
    public sealed class ListBalanceTransactionsRequest
    {
        public int? Limit { get; set; }
        public string? StartsAfter { get; set; }
        public string? PayoutId { get; set; }

        private const string LimitQueryString = "limit";
        private const string StartsAfterQueryString = "startsAfter";
        private const string PayoutIdQueryString = "payoutId";

        internal string ToQueryString() => QueryParameterUtility.BuildQueryString(
            (LimitQueryString, Limit?.ToString()),
            (StartsAfterQueryString, StartsAfter),
            (PayoutIdQueryString, PayoutId)
        );
    }
}
