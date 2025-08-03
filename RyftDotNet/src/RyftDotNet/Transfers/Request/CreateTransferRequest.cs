using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RyftDotNet.Transfers.Request
{
    public sealed class CreateTransferRequest
    {
        [property: JsonPropertyName("amount")]
        public long Amount { get; }

        [property: JsonPropertyName("currency")]
        public string Currency { get; }

        [property: JsonPropertyName("source")]
        public TransferLocationRequest? Source { get; set; }

        [property: JsonPropertyName("destination")]
        public TransferLocationRequest? Destination { get; set; }

        [property: JsonPropertyName("reason")]
        public string? Reason { get; set; }

        [property: JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; set; }

        public CreateTransferRequest(long amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
    }
}
