namespace RyftDotNet.Conversions.Request
{
    public sealed class CreateConversionRequest
    {
        public ConversionSideRequest Sell { get; }

        public ConversionSideRequest Buy { get; }

        public bool TermAgreement { get; }

        public string? FixedSide { get; set; }

        public string? Reason { get; set; }

        public CreateConversionRequest(
            ConversionSideRequest sell,
            ConversionSideRequest buy,
            bool termAgreement)
        {
            Sell = sell;
            Buy = buy;
            TermAgreement = termAgreement;
        }
    }
}
