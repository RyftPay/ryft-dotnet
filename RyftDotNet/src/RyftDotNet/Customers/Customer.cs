using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Utility;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Customers
{
    public sealed class Customer : IEquatable<Customer>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }
        [property: JsonPropertyName("email")]
        public string Email { get; }
        [property: JsonPropertyName("firstName")]
        public string? FirstName { get; }
        [property: JsonPropertyName("lastName")]
        public string? LastName { get; }
        [property: JsonPropertyName("homePhoneNumber")]
        public string? HomePhoneNumber { get; }
        [property: JsonPropertyName("mobilePhoneNumber")]
        public string? MobilePhoneNumber { get; }
        [property: JsonPropertyName("defaultPaymentMethod")]
        public string? DefaultPaymentMethod { get; }
        [property: JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; }

        [property:
            JsonPropertyName("createdTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CreatedTimestamp { get; }

        public Customer(
            string id,
            string email,
            DateTimeOffset createdTimestamp,
            string? firstName = null,
            string? lastName = null,
            string? homePhoneNumber = null,
            string? mobilePhoneNumber = null,
            string? defaultPaymentMethod = null,
            IDictionary<string, string>? metadata = null)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            HomePhoneNumber = homePhoneNumber;
            MobilePhoneNumber = mobilePhoneNumber;
            DefaultPaymentMethod = defaultPaymentMethod;
            Metadata = metadata;
            CreatedTimestamp = createdTimestamp;
        }

        public bool Equals(Customer? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && Email == other.Email
                   && FirstName == other.FirstName
                   && LastName == other.LastName
                   && HomePhoneNumber == other.HomePhoneNumber
                   && MobilePhoneNumber == other.MobilePhoneNumber
                   && DefaultPaymentMethod == other.DefaultPaymentMethod
                   && Utilities.DictionaryEquals(Metadata, other.Metadata)
                   && CreatedTimestamp.Equals(other.CreatedTimestamp));

        public override bool Equals(object? obj)
            => obj is Customer other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Email);
            hashCode.Add(FirstName);
            hashCode.Add(LastName);
            hashCode.Add(HomePhoneNumber);
            hashCode.Add(MobilePhoneNumber);
            hashCode.Add(DefaultPaymentMethod);
            hashCode.Add(Metadata);
            hashCode.Add(CreatedTimestamp);
            return hashCode.ToHashCode();
        }
    }
}
