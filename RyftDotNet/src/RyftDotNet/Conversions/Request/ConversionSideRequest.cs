namespace RyftDotNet.Conversions.Request
{
    public sealed class ConversionSideRequest
    {
        public string Currency { get; }

        public long? Amount { get; set; }

        public ConversionSideRequest(string currency)
        {
            Currency = currency;
        }
    }
}
