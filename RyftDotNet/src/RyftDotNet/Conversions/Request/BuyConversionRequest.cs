namespace RyftDotNet.Conversions.Request
{
    public sealed class BuyConversionRequest
    {
        public string Currency { get; }

        public BuyConversionRequest(string currency)
        {
            Currency = currency;
        }
    }
}
