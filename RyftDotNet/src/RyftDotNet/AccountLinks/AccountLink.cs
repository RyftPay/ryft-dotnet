using System;
using System.Text.Json.Serialization;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.AccountLinks
{
    public sealed class AccountLink : IEquatable<AccountLink>
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

        public AccountLink(
            DateTimeOffset createdTimestamp,
            DateTimeOffset expiresTimestamp,
            string url)
        {
            CreatedTimestamp = createdTimestamp;
            ExpiresTimestamp = expiresTimestamp;
            Url = url;
        }

        public bool Equals(AccountLink? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || CreatedTimestamp.ToUnixTimeSeconds() == other.CreatedTimestamp.ToUnixTimeSeconds()
                   && ExpiresTimestamp.ToUnixTimeSeconds() == other.ExpiresTimestamp.ToUnixTimeSeconds()
                   && Url == other.Url);

        public override bool Equals(object? obj)
            => obj is AccountLink other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                CreatedTimestamp,
                ExpiresTimestamp,
                Url
            ).GetHashCode();
    }
}
