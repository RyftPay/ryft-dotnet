using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Utility
{
    internal static class JsonUtility
    {
        private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions
        {
            WriteIndented = false,
            Converters = { new ConstantValueJsonConverterFactory() },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        internal static string Serialize<TObject>(TObject value)
            => JsonSerializer.Serialize(value, JsonSerializerOptions);

        internal static TObject? Deserialize<TObject>(string json) where TObject : class
            => JsonSerializer.Deserialize<TObject>(json, JsonSerializerOptions);

        internal static object? Deserialize(string json, Type type)
            => JsonSerializer.Deserialize(json, type, JsonSerializerOptions);
    }
}
