using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Common
{
    public sealed class Address : IEquatable<Address>
    {
        [property: JsonPropertyName("firstName")]
        public string? FirstName { get; }

        [property: JsonPropertyName("lastName")]
        public string? LastName { get; }

        [property: JsonPropertyName("lineOne")]
        public string? LineOne { get; }

        [property: JsonPropertyName("lineTwo")]
        public string? LineTwo { get; }

        [property: JsonPropertyName("city")]
        public string? City { get; }

        [property: JsonPropertyName("country")]
        public string Country { get; }

        [property: JsonPropertyName("postalCode")]
        public string PostalCode { get; }

        [property: JsonPropertyName("region")]
        public string? Region { get; }

        public Address(
            string? firstName,
            string? lastName,
            string? lineOne,
            string? lineTwo,
            string? city,
            string country,
            string postalCode,
            string? region)
        {
            FirstName = firstName;
            LastName = lastName;
            LineOne = lineOne;
            LineTwo = lineTwo;
            City = city;
            Country = country;
            PostalCode = postalCode;
            Region = region;
        }

        public bool Equals(Address? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || FirstName == other.FirstName
                   && LastName == other.LastName
                   && LineOne == other.LineOne
                   && LineTwo == other.LineTwo
                   && City == other.City
                   && Region == other.Region
                   && PostalCode == other.PostalCode
                   && Country == other.Country);

        public override bool Equals(object? obj)
            => ReferenceEquals(this, obj) || obj is Address other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                FirstName,
                LastName,
                LineOne,
                LineTwo,
                City,
                Country,
                PostalCode,
                Region
            );
    }
}
