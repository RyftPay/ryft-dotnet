using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Orders
{
    public sealed class InPersonOrderShipping : IEquatable<InPersonOrderShipping>
    {
        [property: JsonPropertyName("businessName")]
        public string? BusinessName { get; }

        [property: JsonPropertyName("firstName")]
        public string FirstName { get; }

        [property: JsonPropertyName("lastName")]
        public string LastName { get; }

        [property: JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; }

        [property: JsonPropertyName("email")]
        public string Email { get; }

        [property: JsonPropertyName("address")]
        public InPersonOrderShippingAddress Address { get; }

        public InPersonOrderShipping(
            string firstName,
            string lastName,
            string phoneNumber,
            string email,
            InPersonOrderShippingAddress address,
            string? businessName = null)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            BusinessName = businessName;
        }

        public bool Equals(InPersonOrderShipping? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || BusinessName == other.BusinessName
                   && FirstName == other.FirstName
                   && LastName == other.LastName
                   && PhoneNumber == other.PhoneNumber
                   && Email == other.Email
                   && Address.Equals(other.Address));

        public override bool Equals(object? obj)
            => obj is InPersonOrderShipping other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(BusinessName);
            hashCode.Add(FirstName);
            hashCode.Add(LastName);
            hashCode.Add(PhoneNumber);
            hashCode.Add(Email);
            hashCode.Add(Address);
            return hashCode.ToHashCode();
        }
    }
}