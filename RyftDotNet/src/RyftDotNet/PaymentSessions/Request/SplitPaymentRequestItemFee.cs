using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class SplitPaymentRequestItemFee
    {
        [property: JsonPropertyName("amount")] public long Amount { get; }

        public SplitPaymentRequestItemFee(long amount)
        {
            Amount = amount;
        }
    }
}
