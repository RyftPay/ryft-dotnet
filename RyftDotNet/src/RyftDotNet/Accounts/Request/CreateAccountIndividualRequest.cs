using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Common;
using RyftDotNet.Common.Request;

namespace RyftDotNet.Accounts.Request
{
    public sealed class CreateAccountIndividualRequest
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

        [property: JsonPropertyName("middleNames")]
        public string? MiddleNames { get; set; }

        [property: JsonPropertyName("countryOfBirth")]
        public string? CountryOfBirth { get; set; }

        [property: JsonPropertyName("phoneNumber")]
        public string? PhoneNumber { get; set; }

        public CreateAccountIndividualRequest(
            string firstName,
            string lastName,
            string email,
            DateOfEvent dateOfBirth,
            Gender gender,
            IEnumerable<string> nationalities,
            AccountAddressRequest address)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Nationalities = nationalities;
            Address = address;
        }
    }
}
