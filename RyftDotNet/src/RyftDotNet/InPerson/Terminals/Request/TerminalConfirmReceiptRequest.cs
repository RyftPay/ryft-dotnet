using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Terminals.Request
{
    public sealed class TerminalConfirmReceiptRequest
    {
        [JsonPropertyName("customerCopy")]
        public bool? CustomerCopy { get; set; }

        [JsonPropertyName("merchantCopy")]
        public bool? MerchantCopy { get; set; }
    }
}