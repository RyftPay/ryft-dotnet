using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Terminals.Request
{
    public sealed class TerminalRefundRequest
    {
        [JsonPropertyName("paymentSession")]
        public TerminalRefundPaymentSessionRequest PaymentSession { get; }

        [JsonPropertyName("amount")]
        public int? Amount { get; set; }

        [JsonPropertyName("refundPlatformFee")]
        public bool? RefundPlatformFee { get; set; }

        [JsonPropertyName("settings")]
        public TerminalTransactionSettingsRequest? Settings { get; set; }

        public TerminalRefundRequest(TerminalRefundPaymentSessionRequest paymentSession)
        {
            PaymentSession = paymentSession;
        }
    }
}
