using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Common;

namespace RyftDotNet.Webhooks
{
    public sealed class UpdateWebhookRequest
    {
        [property: JsonPropertyName("url")]
        public string? Url { get; set; }

        [property: JsonPropertyName("active")]
        public bool? Active { get; set; }

        [property: JsonPropertyName("eventTypes")]
        public IEnumerable<EventType>? EventTypes { get; set; }
    }
}
