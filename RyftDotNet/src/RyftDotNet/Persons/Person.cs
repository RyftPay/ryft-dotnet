using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Common;
using RyftDotNet.Utility;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Persons
{
    public sealed class Person : IEquatable<Person>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("firstName")]
        public string FirstName { get; }

        [property: JsonPropertyName("lastName")]
        public string LastName { get; }

        [property: JsonPropertyName("dateOfBirth")]
        public DateOfEvent DateOfBirth { get; }

        [property: JsonPropertyName("nationalities")]
        public IEnumerable<string> Nationalities { get; }

        [property: JsonPropertyName("address")]
        public AccountAddress Address { get; }

        [property: JsonPropertyName("businessRoles")]
        public IEnumerable<PersonBusinessRole> BusinessRoles { get; }

        [property: JsonPropertyName("verification")]
        public PersonVerification Verification { get; }

        [property:
            JsonPropertyName("createdTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CreatedTimestamp { get; }

        [property:
            JsonPropertyName("lastUpdatedTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset LastUpdatedTimestamp { get; }

        [property: JsonPropertyName("middleNames")]
        public string? MiddleNames { get; }

        [property: JsonPropertyName("email")]
        public string? Email { get; }

        [property: JsonPropertyName("countryOfBirth")]
        public string? CountryOfBirth { get; }

        [property: JsonPropertyName("gender")]
        public Gender? Gender { get; }

        [property: JsonPropertyName("phoneNumber")]
        public string? PhoneNumber { get; }

        [property: JsonPropertyName("documents")]
        public IEnumerable<AccountDocument>? Documents { get; }

        [property: JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; }

        public Person(
            string id,
            string firstName,
            string lastName,
            DateOfEvent dateOfBirth,
            IEnumerable<string> nationalities,
            AccountAddress address,
            IEnumerable<PersonBusinessRole> businessRoles,
            PersonVerification verification,
            DateTimeOffset createdTimestamp,
            DateTimeOffset lastUpdatedTimestamp,
            string? middleNames = null,
            string? email = null,
            string? countryOfBirth = null,
            Gender? gender = null,
            string? phoneNumber = null,
            IEnumerable<AccountDocument>? documents = null,
            IDictionary<string, string>? metadata = null)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Nationalities = nationalities;
            Address = address;
            BusinessRoles = businessRoles;
            Verification = verification;
            CreatedTimestamp = createdTimestamp;
            LastUpdatedTimestamp = lastUpdatedTimestamp;
            MiddleNames = middleNames;
            Email = email;
            CountryOfBirth = countryOfBirth;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Documents = documents;
            Metadata = metadata;
        }

        public bool Equals(Person? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && FirstName == other.FirstName
                   && LastName == other.LastName
                   && DateOfBirth.Equals(other.DateOfBirth)
                   && Utilities.SequenceEqual(Nationalities, other.Nationalities)
                   && Utilities.SequenceEqual(BusinessRoles, other.BusinessRoles)
                   && Verification.Equals(other.Verification)
                   && CreatedTimestamp.Equals(other.CreatedTimestamp)
                   && LastUpdatedTimestamp.Equals(other.LastUpdatedTimestamp)
                   && MiddleNames == other.MiddleNames
                   && Email == other.Email
                   && CountryOfBirth == other.CountryOfBirth
                   && Gender == other.Gender
                   && PhoneNumber == other.PhoneNumber
                   && Utilities.SequenceEqual(Documents, other.Documents)
                   && Utilities.DictionaryEquals(Metadata, other.Metadata));

        public override bool Equals(object? obj)
            => obj is Person other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(FirstName);
            hashCode.Add(LastName);
            hashCode.Add(DateOfBirth);
            hashCode.Add(Nationalities);
            hashCode.Add(Address);
            hashCode.Add(BusinessRoles);
            hashCode.Add(Verification);
            hashCode.Add(CreatedTimestamp);
            hashCode.Add(LastUpdatedTimestamp);
            hashCode.Add(MiddleNames);
            hashCode.Add(Email);
            hashCode.Add(CountryOfBirth);
            hashCode.Add(Gender);
            hashCode.Add(PhoneNumber);
            hashCode.Add(Documents);
            hashCode.Add(Metadata);
            return hashCode.ToHashCode();
        }
    }
}
