using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class AttemptPaymentPaymentMethodRequest
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("cvc")]
        public string? Cvc { get; set; }

        public AttemptPaymentPaymentMethodRequest(string id)
        {
            Id = id;
        }
    }
}
