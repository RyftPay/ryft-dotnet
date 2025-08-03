using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Common
{
    public sealed class AccountAddress : IEquatable<AccountAddress>
    {
        [property: JsonPropertyName("country")]
        public string Country { get; }

        [property: JsonPropertyName("postalCode")]
        public string? PostalCode { get; }

        [property: JsonPropertyName("lineOne")]
        public string? LineOne { get; }

        [property: JsonPropertyName("lineTwo")]
        public string? LineTwo { get; }

        [property: JsonPropertyName("city")]
        public string? City { get; }

        [property: JsonPropertyName("region")]
        public string? Region { get; }

        public AccountAddress(
            string country,
            string? postalCode,
            string? lineOne = null,
            string? lineTwo = null,
            string? city = null,
            string? region = null)
        {
            Country = country;
            PostalCode = postalCode;
            LineOne = lineOne;
            LineTwo = lineTwo;
            City = city;
            Region = region;
        }

        public bool Equals(AccountAddress? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || PostalCode == other.PostalCode
                   && Country == other.Country
                   && LineOne == other.LineOne
                   && LineTwo == other.LineTwo
                   && City == other.City
                   && Region == other.Region);

        public override bool Equals(object? obj)
            => ReferenceEquals(this, obj) || obj is AccountAddress other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                Country,
                PostalCode,
                LineOne,
                LineTwo,
                City,
                Region
            );
    }
}
