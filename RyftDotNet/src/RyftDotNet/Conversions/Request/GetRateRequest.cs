using RyftDotNet.Client.Error;
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
            if (string.IsNullOrWhiteSpace(buyCurrency))
            {
                throw new RyftArgumentException($"{nameof(buyCurrency)} is required");
            }
            if (string.IsNullOrWhiteSpace(sellCurrency))
            {
                throw new RyftArgumentException($"{nameof(sellCurrency)} is required");
            }
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
