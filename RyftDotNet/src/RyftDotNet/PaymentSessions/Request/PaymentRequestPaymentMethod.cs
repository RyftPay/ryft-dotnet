using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class PaymentRequestPaymentMethod
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("cvc")]
        public string? Cvc { get; set; }

        public PaymentRequestPaymentMethod(string id)
        {
            Id = id;
        }
    }
}
