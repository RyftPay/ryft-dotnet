using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.PaymentSessions.Request;

namespace RyftDotNet.InPerson.Terminals.Request
{
    public sealed class TerminalPaymentSessionRequest
    {
        [JsonPropertyName("platformFee")]
        public int? PlatformFee { get; set; }

        [JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; set; }

        [JsonPropertyName("paymentSettings")]
        public PaymentSettingsRequest? PaymentSettings { get; set; }
    }
}
