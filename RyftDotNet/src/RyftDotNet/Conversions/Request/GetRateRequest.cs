using RyftDotNet.Utility;

namespace RyftDotNet.Conversions.Request
{
    public sealed class GetRateRequest
    {
        public string? BuyCurrency { get; set; }
        public string? SellCurrency { get; set; }
        public long? Amount { get; set; }

        private const string BuyCurrencyQueryString = "buyCurrency";
        private const string SellCurrencyQueryString = "sellCurrency";
        private const string AmountQueryString = "amount";

        internal string ToQueryString() => QueryParameterUtility.BuildQueryString(
            (BuyCurrencyQueryString, BuyCurrency),
            (SellCurrencyQueryString, SellCurrency),
            (AmountQueryString, Amount?.ToString())
        );
    }
}
