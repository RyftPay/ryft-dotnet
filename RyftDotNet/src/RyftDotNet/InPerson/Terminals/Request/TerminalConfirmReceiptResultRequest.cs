using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Terminals.Request
{
    public sealed class TerminalConfirmReceiptResultRequest
    {
        [JsonPropertyName("status")]
        public TerminalReceiptPrintingStatus Status { get; }

        public TerminalConfirmReceiptResultRequest(TerminalReceiptPrintingStatus status)
        {
            Status = status;
        }
    }
}
