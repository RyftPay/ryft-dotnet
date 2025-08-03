using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class AttemptPaymentPaymentMethodOptions
    {
        [property: JsonPropertyName("store")] public bool Store { get; set; } = false;
    }
}
