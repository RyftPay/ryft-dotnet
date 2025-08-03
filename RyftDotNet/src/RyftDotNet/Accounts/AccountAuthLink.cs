using System;
using System.Text.Json.Serialization;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Accounts
{
    public sealed class AccountAuthLink
    {
        [property:
            JsonPropertyName("createdTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CreatedTimestamp { get; }

        [property:
            JsonPropertyName("expiresTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset ExpiresTimestamp { get; }

        [property: JsonPropertyName("url")]
        public string Url { get; }

        public AccountAuthLink(
            DateTimeOffset createdTimestamp,
            DateTimeOffset expiresTimestamp,
            string url)
        {
            CreatedTimestamp = createdTimestamp;
            ExpiresTimestamp = expiresTimestamp;
            Url = url;
        }
    }
}
