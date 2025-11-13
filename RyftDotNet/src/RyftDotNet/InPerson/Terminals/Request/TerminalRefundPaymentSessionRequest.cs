using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Terminals.Request
{
    public sealed class TerminalRefundPaymentSessionRequest
    {
        [JsonPropertyName("id")]
        public string Id { get; }

        public TerminalRefundPaymentSessionRequest(string id)
        {
            Id = id;
        }
    }
}
