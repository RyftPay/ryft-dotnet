using System;
using System.Text.Json.Serialization;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Accounts
{
    public sealed class AccountTermsOfServiceAcceptance : IEquatable<AccountTermsOfServiceAcceptance>
    {
        [property: JsonPropertyName("ipAddress")]
        public string IpAddress { get; }

        [property:
            JsonPropertyName("when"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset When { get; }

        [property: JsonPropertyName("userAgent")]
        public string? UserAgent { get; }

        public AccountTermsOfServiceAcceptance(
            string ipAddress,
            DateTimeOffset when,
            string? userAgent = null)
        {
            IpAddress = ipAddress;
            UserAgent = userAgent;
            When = when;
        }

        public bool Equals(AccountTermsOfServiceAcceptance? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || IpAddress == other.IpAddress
                   && When.Equals(other.When)
                   && UserAgent == other.UserAgent);

        public override bool Equals(object? obj)
            => obj is AccountTermsOfServiceAcceptance other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                IpAddress,
                When,
                UserAgent
            ).GetHashCode();
    }
}
