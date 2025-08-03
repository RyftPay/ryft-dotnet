using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Utility;

namespace RyftDotNet.PaymentSessions
{
    public sealed class PaymentSessionCustomerDetails : IEquatable<PaymentSessionCustomerDetails>
    {
        [property: JsonPropertyName("id")]
        public string? Id { get; }

        [property: JsonPropertyName("firstName")]
        public string? FirstName { get; }

        [property: JsonPropertyName("lastName")]
        public string? LastName { get; }

        [property: JsonPropertyName("homePhoneNumber")]
        public string? HomePhoneNumber { get; }

        [property: JsonPropertyName("mobilePhoneNumber")]
        public string? MobilePhoneNumber { get; }

        [property: JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; }

        public PaymentSessionCustomerDetails(
            string? id = null,
            string? firstName = null,
            string? lastName = null,
            string? homePhoneNumber = null,
            string? mobilePhoneNumber = null,
            IDictionary<string, string>? metadata = null)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            HomePhoneNumber = homePhoneNumber;
            MobilePhoneNumber = mobilePhoneNumber;
            Metadata = metadata;
        }

        public bool Equals(PaymentSessionCustomerDetails? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && FirstName == other.FirstName
                   && LastName == other.LastName
                   && HomePhoneNumber == other.HomePhoneNumber
                   && MobilePhoneNumber == other.MobilePhoneNumber
                   && Utilities.DictionaryEquals(Metadata, other.Metadata));

        public override bool Equals(object? obj)
            => obj is PaymentSessionCustomerDetails other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                Id,
                FirstName,
                LastName,
                HomePhoneNumber,
                MobilePhoneNumber,
                Metadata
            ).GetHashCode();
    }
}
