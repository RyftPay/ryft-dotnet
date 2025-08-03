using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using RyftDotNet.Common;

namespace RyftDotNet.Utility.JsonConverters
{
    public sealed class ConstantValueJsonConverter<T> : JsonConverter<T> where T : ConstantValue
    {
        private readonly Func<string, T> readFromString;

        public ConstantValueJsonConverter(Func<string, T> readFromString)
        {
            this.readFromString = readFromString;
        }

        public override T Read(
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
            return readFromString(value!);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.Value);
    }
}
