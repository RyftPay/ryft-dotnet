using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Common
{
    public sealed class ShippingDetails : IEquatable<ShippingDetails>
    {
        [property: JsonPropertyName("address")]
        public Address Address { get; }

        [property: JsonPropertyName("phoneNumber")]
        public string? PhoneNumber { get; }

        public ShippingDetails(Address address, string? phoneNumber = null)
        {
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public bool Equals(ShippingDetails? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Equals(Address, other.Address)
                   && PhoneNumber == other.PhoneNumber);

        public override bool Equals(object? obj)
            => obj is ShippingDetails other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Address, PhoneNumber).GetHashCode();
    }
}
