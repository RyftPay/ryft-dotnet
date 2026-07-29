using System.Text.Json.Serialization;

namespace RyftDotNet.Conversions.Request
{
    public sealed class CreateConversionRequest
    {
        [JsonRequired]
        public ConversionSideRequest Sell { get; }

        [JsonRequired]
        public ConversionSideRequest Buy { get; }

        [JsonRequired]
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
