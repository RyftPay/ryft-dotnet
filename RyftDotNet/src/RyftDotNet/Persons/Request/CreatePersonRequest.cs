using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Common;
using RyftDotNet.Common.Request;

namespace RyftDotNet.Persons.Request
{
    public sealed class CreatePersonRequest
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
        public Gender Gender { get; }

        [property: JsonPropertyName("nationalities")]
        public IEnumerable<string> Nationalities { get; }

        [property: JsonPropertyName("address")]
        public AccountAddressRequest Address { get; }

        [property: JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; }

        [property: JsonPropertyName("businessRoles")]
        public IEnumerable<PersonBusinessRole> BusinessRoles { get; }

        [property: JsonPropertyName("middleNames")]
        public string? MiddleNames { get; set; }

        [property: JsonPropertyName("countryOfBirth")]
        public string? CountryOfBirth { get; set; }

        [property: JsonPropertyName("documents")]
        public IEnumerable<AccountDocumentRequest>? Documents { get; set; }

        [property: JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; set; }

        public CreatePersonRequest(
            string firstName,
            string lastName,
            string email,
            DateOfEvent dateOfBirth,
            Gender gender,
            IEnumerable<string> nationalities,
            AccountAddressRequest address,
            string phoneNumber,
            IEnumerable<PersonBusinessRole> businessRoles)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Nationalities = nationalities;
            Address = address;
            PhoneNumber = phoneNumber;
            BusinessRoles = businessRoles;
        }
    }
}
