using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Locations
{
    public sealed class InPersonLocationAddress : IEquatable<InPersonLocationAddress>
    {
        [property: JsonPropertyName("lineOne")]
        public string LineOne { get; }

        [property: JsonPropertyName("lineTwo")]
        public string? LineTwo { get; }

        [property: JsonPropertyName("city")]
        public string City { get; }

        [property: JsonPropertyName("country")]
        public string Country { get; }

        [property: JsonPropertyName("postalCode")]
        public string PostalCode { get; }

        [property: JsonPropertyName("region")]
        public string? Region { get; }

        public InPersonLocationAddress(
            string lineOne,
            string city,
            string country,
            string postalCode,
            string? lineTwo = null,
            string? region = null)
        {
            LineOne = lineOne;
            City = city;
            Country = country;
            PostalCode = postalCode;
            LineTwo = lineTwo;
            Region = region;
        }

        public bool Equals(InPersonLocationAddress? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || LineOne == other.LineOne
                   && LineTwo == other.LineTwo
                   && City == other.City
                   && Country == other.Country
                   && PostalCode == other.PostalCode
                   && Region == other.Region);

        public override bool Equals(object? obj)
            => obj is InPersonLocationAddress other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(LineOne);
            hashCode.Add(LineTwo);
            hashCode.Add(City);
            hashCode.Add(Country);
            hashCode.Add(PostalCode);
            hashCode.Add(Region);
            return hashCode.ToHashCode();
        }
    }
}