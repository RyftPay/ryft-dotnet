using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Orders
{
    public sealed class InPersonOrderTracking
    {
        [JsonPropertyName("items")]
        public IEnumerable<InPersonOrderTrackingItem> Items { get; }

        public InPersonOrderTracking(IEnumerable<InPersonOrderTrackingItem> items)
        {
            Items = items;
        }
    }
}
