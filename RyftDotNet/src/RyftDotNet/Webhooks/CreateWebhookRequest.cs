using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Common;

namespace RyftDotNet.Webhooks
{
    public sealed class CreateWebhookRequest
    {
        [property: JsonPropertyName("url")]
        public string Url { get; }

        [property: JsonPropertyName("active")]
        public bool Active { get; }

        [property: JsonPropertyName("eventTypes")]
        public IEnumerable<EventType> EventTypes { get; }

        public CreateWebhookRequest(
            string url,
            bool active,
            IEnumerable<EventType> eventTypes)
        {
            Url = url;
            Active = active;
            EventTypes = eventTypes;
        }
    }
}
