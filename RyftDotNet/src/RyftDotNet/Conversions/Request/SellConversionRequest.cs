namespace RyftDotNet.Conversions.Request
{
    public sealed class SellConversionRequest
    {
        public string Currency { get; }

        public long Amount { get; }

        public SellConversionRequest(string currency, long amount)
        {
            Currency = currency;
            Amount = amount;
        }
    }
}
