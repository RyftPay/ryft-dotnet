using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class PreviousPaymentRequest
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        public PreviousPaymentRequest(string id)
        {
            Id = id;
        }
    }
}
