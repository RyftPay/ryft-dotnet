using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class CreatePaymentSessionAttemptPaymentRequest
    {
        [property: JsonPropertyName("paymentMethod")]
        public PaymentRequestPaymentMethod PaymentMethod { get; }

        public CreatePaymentSessionAttemptPaymentRequest(
            PaymentRequestPaymentMethod paymentMethod)
        {
            PaymentMethod = paymentMethod;
        }
    }
}
