using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Terminals.Request
{
    public sealed class TerminalTransactionSettingsRequest
    {
        [JsonPropertyName("receiptPrintingSource")]
        public TerminalReceiptPrintingSource? ReceiptPrintingSource { get; set; }
    }
}
