using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Common;
using RyftDotNet.Common.Request;

namespace RyftDotNet.Accounts.Request
{
    public sealed class UpdateAccountIndividualRequest
    {
        [property: JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [property: JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [property: JsonPropertyName("email")]
        public string? Email { get; set; }

        [property: JsonPropertyName("dateOfBirth")]
        public DateOfEvent? DateOfBirth { get; set; }

        [property: JsonPropertyName("gender")]
        public Gender? Gender { get; set; }

        [property: JsonPropertyName("nationalities")]
        public IEnumerable<string>? Nationalities { get; set; }

        [property: JsonPropertyName("address")]
        public AccountAddressRequest? Address { get; set; }

        [property: JsonPropertyName("middleNames")]
        public string? MiddleNames { get; set; }

        [property: JsonPropertyName("countryOfBirth")]
        public string? CountryOfBirth { get; set; }

        [property: JsonPropertyName("phoneNumber")]
        public string? PhoneNumber { get; set; }

        [property: JsonPropertyName("documents")]
        public IEnumerable<AccountDocumentRequest>? Documents { get; set; }
    }
}
