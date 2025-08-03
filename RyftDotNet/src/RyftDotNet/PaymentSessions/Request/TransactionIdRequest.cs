using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class TransactionIdRequest
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        public TransactionIdRequest(string id)
        {
            Id = id;
        }
    }
}
