using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class CardDetailsRequest
    {
        [property: JsonPropertyName("number")]
        public string Number { get; }

        [property: JsonPropertyName("expiryMonth")]
        public string ExpiryMonth { get; }

        [property: JsonPropertyName("expiryYear")]
        public string ExpiryYear { get; }

        [property: JsonPropertyName("cvc")]
        public string? Cvc { get; set; }

        [property: JsonPropertyName("name")]
        public string? Name { get; set; }

        public CardDetailsRequest(
            string number,
            string expiryMonth,
            string expiryYear,
            string? cvc = null)
        {
            Number = number;
            ExpiryMonth = expiryMonth;
            ExpiryYear = expiryYear;
            Cvc = cvc;
        }
    }
}
