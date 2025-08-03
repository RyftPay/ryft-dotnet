using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class OrderDetailsRequest
    {
        [property: JsonPropertyName("items")]
        public IEnumerable<OrderLineItemRequest> Items { get; }

        public OrderDetailsRequest(IEnumerable<OrderLineItemRequest> items)
        {
            Items = items;
        }
    }
}
