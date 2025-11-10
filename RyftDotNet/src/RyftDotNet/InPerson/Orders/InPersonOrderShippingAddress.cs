using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Orders
{
    public sealed class InPersonOrderShippingAddress : IEquatable<InPersonOrderShippingAddress>
    {
        [property: JsonPropertyName("lineOne")]
        public string LineOne { get; }

        [property: JsonPropertyName("lineTwo")]
        public string? LineTwo { get; }

        [property: JsonPropertyName("city")]
        public string City { get; }

        [property: JsonPropertyName("region")]
        public string? Region { get; }

        [property: JsonPropertyName("postalCode")]
        public string PostalCode { get; }

        [property: JsonPropertyName("country")]
        public string Country { get; }

        public InPersonOrderShippingAddress(
            string lineOne,
            string city,
            string postalCode,
            string country,
            string? lineTwo = null,
            string? region = null)
        {
            LineOne = lineOne;
            City = city;
            PostalCode = postalCode;
            Country = country;
            LineTwo = lineTwo;
            Region = region;
        }

        public bool Equals(InPersonOrderShippingAddress? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || LineOne == other.LineOne
                   && LineTwo == other.LineTwo
                   && City == other.City
                   && Region == other.Region
                   && PostalCode == other.PostalCode
                   && Country == other.Country);

        public override bool Equals(object? obj)
            => obj is InPersonOrderShippingAddress other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(LineOne);
            hashCode.Add(LineTwo);
            hashCode.Add(City);
            hashCode.Add(Region);
            hashCode.Add(PostalCode);
            hashCode.Add(Country);
            return hashCode.ToHashCode();
        }
    }
}