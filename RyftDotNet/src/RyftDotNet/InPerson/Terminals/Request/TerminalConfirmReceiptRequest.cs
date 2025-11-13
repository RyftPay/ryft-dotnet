using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Terminals.Request
{
    public sealed class TerminalConfirmReceiptRequest
    {
        [JsonPropertyName("customerCopy")]
        public TerminalConfirmReceiptResultRequest? CustomerCopy { get; set; }

        [JsonPropertyName("merchantCopy")]
        public TerminalConfirmReceiptResultRequest? MerchantCopy { get; set; }
    }
}
