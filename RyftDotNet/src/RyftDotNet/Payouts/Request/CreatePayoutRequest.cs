using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RyftDotNet.Payouts.Request
{
    public sealed class CreatePayoutRequest
    {
        [property: JsonPropertyName("amount")]
        public long Amount { get; }

        [property: JsonPropertyName("currency")]
        public string Currency { get; }

        [property: JsonPropertyName("payoutMethodId")]
        public string PayoutMethodId { get; }

        [property: JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; set; }

        public CreatePayoutRequest(
            long amount,
            string currency,
            string payoutMethodId)
        {
            Amount = amount;
            Currency = currency;
            PayoutMethodId = payoutMethodId;
        }
    }
}
