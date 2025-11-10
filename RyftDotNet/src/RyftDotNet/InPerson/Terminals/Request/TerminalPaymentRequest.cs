using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Terminals.Request
{
    public sealed class TerminalPaymentRequest
    {
        [JsonPropertyName("amounts")]
        public TerminalPaymentAmountsRequest Amounts { get; }

        [JsonPropertyName("currency")]
        public string Currency { get; }

        [JsonPropertyName("paymentSession")]
        public TerminalPaymentSessionRequest? PaymentSession { get; set; }

        [JsonPropertyName("settings")]
        public TerminalTransactionSettingsRequest? Settings { get; set; }

        public TerminalPaymentRequest(TerminalPaymentAmountsRequest amounts, string currency)
        {
            Amounts = amounts;
            Currency = currency;
        }
    }
}