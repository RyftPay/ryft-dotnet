using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class SplitPaymentRequestItem
    {
        [property: JsonPropertyName("accountId")]
        public string AccountId { get; }

        [property: JsonPropertyName("amount")]
        public long Amount { get; }

        [property: JsonPropertyName("description")]
        public string? Description { get; set; }

        [property: JsonPropertyName("fee")]
        public SplitPaymentRequestItemFee? Fee { get; set; }

        [property: JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; set; }

        public SplitPaymentRequestItem(
            string accountId,
            long amount)
        {
            AccountId = accountId;
            Amount = amount;
        }
    }
}
