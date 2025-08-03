using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class SplitPaymentRequest
    {
        [property: JsonPropertyName("items")]
        public IEnumerable<SplitPaymentRequestItem> Items { get; }

        public SplitPaymentRequest(IEnumerable<SplitPaymentRequestItem> items)
        {
            Items = items;
        }
    }
}
