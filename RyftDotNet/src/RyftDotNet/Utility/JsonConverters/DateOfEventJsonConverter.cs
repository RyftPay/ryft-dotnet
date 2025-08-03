using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using RyftDotNet.Common;

namespace RyftDotNet.Utility.JsonConverters
{
    public sealed class DateOfEventJsonConverter : JsonConverter<DateOfEvent>
    {
        public override DateOfEvent Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            string? value = reader.GetString();
            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException($"The JSON value '{value}' could not be converted to expected type 'string'.");
            }
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new JsonException($"The JSON value '{value}' was missing or blank.");
            }
            string[] parts = value!.Split('-');
            return new DateOfEvent(
                year: int.Parse(parts[0]),
                month: int.Parse(parts[1]),
                day: int.Parse(parts[2])
            );
        }

        public override void Write(Utf8JsonWriter writer, DateOfEvent value, JsonSerializerOptions options)
            => writer.WriteStringValue($"{value.Year:d4}-{value.Month:d2}-{value.Day:d2}");
    }
}
