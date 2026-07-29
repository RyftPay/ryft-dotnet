namespace RyftDotNet.Conversions.Request
{
    public sealed class CreateConversionRequest
    {
        public SellConversionRequest Sell { get; }

        public BuyConversionRequest Buy { get; }

        public bool TermAgreement { get; }

        public string? FixedSide { get; set; }

        public string? Reason { get; set; }

        public CreateConversionRequest(
            SellConversionRequest sell,
            BuyConversionRequest buy,
            bool termAgreement)
        {
            Sell = sell;
            Buy = buy;
            TermAgreement = termAgreement;
        }
    }
}
