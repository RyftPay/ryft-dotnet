using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Terminals.Request
{
    public sealed class TerminalPaymentAmountsRequest
    {
        [JsonPropertyName("requested")]
        public int Requested { get; }

        public TerminalPaymentAmountsRequest(int requested)
        {
            Requested = requested;
        }
    }
}
