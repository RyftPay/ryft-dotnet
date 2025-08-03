using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class PaymentMethodOptionSettingsRequest
    {
        [property: JsonPropertyName("disabled")]
        public IEnumerable<string> Disabled { get; }

        public PaymentMethodOptionSettingsRequest(IEnumerable<string> disabled)
        {
            Disabled = disabled;
        }
    }
}
