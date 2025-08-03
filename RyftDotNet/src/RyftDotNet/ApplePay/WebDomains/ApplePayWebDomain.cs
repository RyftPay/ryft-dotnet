using System;
using System.Text.Json.Serialization;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.ApplePay.WebDomains
{
    public sealed class ApplePayWebDomain : IEquatable<ApplePayWebDomain>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("domainName")]
        public string DomainName { get; }

        [property:
            JsonPropertyName("createdTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CreatedTimestamp { get; }

        public ApplePayWebDomain(
            string id,
            string domainName,
            DateTimeOffset createdTimestamp)
        {
            Id = id;
            DomainName = domainName;
            CreatedTimestamp = createdTimestamp;
        }

        public bool Equals(ApplePayWebDomain? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && DomainName == other.DomainName
                   && CreatedTimestamp.ToUnixTimeSeconds() == other.CreatedTimestamp.ToUnixTimeSeconds());

        public override bool Equals(object? obj)
            => obj is ApplePayWebDomain other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                Id,
                DomainName,
                CreatedTimestamp
            ).GetHashCode();
    }
}
