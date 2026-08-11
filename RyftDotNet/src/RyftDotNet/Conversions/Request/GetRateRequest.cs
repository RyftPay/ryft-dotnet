using RyftDotNet.Utility;

namespace RyftDotNet.Conversions.Request
{
    public sealed class GetRateRequest
    {
        public string BuyCurrency { get; }
        public string SellCurrency { get; }
        public long Amount { get; }

        private const string BuyCurrencyQueryString = "buyCurrency";
        private const string SellCurrencyQueryString = "sellCurrency";
        private const string AmountQueryString = "amount";

        public GetRateRequest(string buyCurrency, string sellCurrency, long amount)
        {
            BuyCurrency = buyCurrency;
            SellCurrency = sellCurrency;
            Amount = amount;
        }

        internal string ToQueryString() => QueryParameterUtility.BuildQueryString(
            (BuyCurrencyQueryString, BuyCurrency),
            (SellCurrencyQueryString, SellCurrency),
            (AmountQueryString, Amount.ToString())
        );
    }
}
