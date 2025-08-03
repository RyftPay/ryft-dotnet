using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using RyftDotNet.Common;
using RyftDotNet.Events;

namespace RyftDotNet.Utility.JsonConverters
{
    public sealed class EventJsonConverter : JsonConverter<Event>
    {
        private const string IdPropertyName = "id";
        private const string EventTypePropertyName = "eventType";
        private const string DataPropertyName = "data";
        private const string EndpointsPropertyName = "endpoints";
        private const string AccountIdPropertyName = "accountId";
        private const string CreatedTimestampPropertyName = "createdTimestamp";

        private const string EventEndpointWebhookIdPropertyName = "webhookId";
        private const string EventDataAcknowledgedPropertyName = "acknowledged";
        private const string EventDataAttemptsPropertyName = "attempts";

        public override bool CanConvert(Type typeToConvert)
            => typeof(Event).IsAssignableFrom(typeToConvert);

        public override Event Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException("The JSON value was not of the expected type, cannot read.");
            }
            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            string id = jsonDocument.RootElement.GetProperty(IdPropertyName).GetString()!;
            var eventType = new EventType(jsonDocument.RootElement.GetProperty(EventTypePropertyName).GetString()!);
            var eventEndpoints = new List<EventEndpoint>();
            if (jsonDocument.RootElement.TryGetProperty(EndpointsPropertyName, out var endpointsElement))
            {
                eventEndpoints = endpointsElement
                    .EnumerateArray()
                    .Select(ParseEventEndpoint)
                    .ToList();
            }
            var dataElement = jsonDocument.RootElement.GetProperty(DataPropertyName);
            var eventData = ParseEventData(eventType, dataElement);
            string? accountId = null;
            if (jsonDocument.RootElement.TryGetProperty(AccountIdPropertyName, out var accountIdElement))
            {
                accountId = accountIdElement.GetString();
            }
            var createdTimestamp = DateTimeOffset.FromUnixTimeSeconds(
                jsonDocument.RootElement.GetProperty(CreatedTimestampPropertyName).GetInt64()
            );
            return new Event(
                id,
                eventType,
                eventData,
                eventEndpoints,
                accountId,
                createdTimestamp
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            Event value,
            JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        private static EventEndpoint ParseEventEndpoint(JsonElement element)
        {
            string webhookId = element.GetProperty(EventEndpointWebhookIdPropertyName).GetString()!;
            bool acknowledged = element.GetProperty(EventDataAcknowledgedPropertyName).GetBoolean();
            int attempts = element.GetProperty(EventDataAttemptsPropertyName).GetInt32();
            return new EventEndpoint(webhookId, acknowledged, attempts);
        }

        private static EventData ParseEventData(
            EventType eventType,
            JsonElement element)
        {
            string rawJson = element.GetRawText();
            object? apiObject = null;
            if (eventType.ApiObjectType != null)
            {
                apiObject = JsonUtility.Deserialize(rawJson, eventType.ApiObjectType);
            }
            return new EventData(apiObject);
        }
    }
}
