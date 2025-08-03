using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Common;
using RyftDotNet.Utility;

namespace RyftDotNet.Accounts
{
    public sealed class AccountIndividual : IEquatable<AccountIndividual>
    {
        [property: JsonPropertyName("firstName")]
        public string FirstName { get; }

        [property: JsonPropertyName("lastName")]
        public string LastName { get; }

        [property: JsonPropertyName("email")]
        public string Email { get; }

        [property: JsonPropertyName("dateOfBirth")]
        public DateOfEvent DateOfBirth { get; }

        [property: JsonPropertyName("gender")]
        public Gender? Gender { get; }

        [property: JsonPropertyName("nationalities")]
        public IEnumerable<string>? Nationalities { get; }

        [property: JsonPropertyName("address")]
        public AccountAddress? Address { get; }

        [property: JsonPropertyName("middleNames")]
        public string? MiddleNames { get; }

        [property: JsonPropertyName("countryOfBirth")]
        public string? CountryOfBirth { get; }

        [property: JsonPropertyName("phoneNumber")]
        public string? PhoneNumber { get; }

        [property: JsonPropertyName("documents")]
        public IEnumerable<AccountDocument>? Documents { get; }

        public AccountIndividual(
            string firstName,
            string lastName,
            string email,
            DateOfEvent dateOfBirth,
            Gender? gender = null,
            IEnumerable<string>? nationalities = null,
            AccountAddress? address = null,
            string? middleNames = null,
            string? countryOfBirth = null,
            string? phoneNumber = null,
            IEnumerable<AccountDocument>? documents = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Nationalities = nationalities;
            Address = address;
            MiddleNames = middleNames;
            CountryOfBirth = countryOfBirth;
            PhoneNumber = phoneNumber;
            Documents = documents;
        }

        public bool Equals(AccountIndividual? other)
            => !ReferenceEquals(null, other)
                   && (ReferenceEquals(this, other)
                       || FirstName == other.FirstName
                       && LastName == other.LastName
                       && Email == other.Email
                       && DateOfBirth.Equals(other.DateOfBirth)
                       && Gender == other.Gender
                       && Utilities.SequenceEqual(Nationalities, other.Nationalities)
                       && Equals(Address, other.Address)
                       && MiddleNames == other.MiddleNames
                       && CountryOfBirth == other.CountryOfBirth
                       && PhoneNumber == other.PhoneNumber
                       && Utilities.SequenceEqual(Documents, other.Documents));

        public override bool Equals(object? obj)
            => obj is AccountIndividual other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(FirstName);
            hashCode.Add(LastName);
            hashCode.Add(Email);
            hashCode.Add(DateOfBirth);
            hashCode.Add(Gender);
            hashCode.Add(Nationalities);
            hashCode.Add(Address);
            hashCode.Add(MiddleNames);
            hashCode.Add(CountryOfBirth);
            hashCode.Add(PhoneNumber);
            hashCode.Add(Documents);
            return hashCode.ToHashCode();
        }
    }
}
