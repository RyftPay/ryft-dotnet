using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RyftDotNet.Customers.Request
{
    public sealed class CreateCustomerRequest
    {
        [property: JsonPropertyName("email")]
        public string Email { get; }

        [property: JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [property: JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [property: JsonPropertyName("homePhoneNumber")]
        public string? HomePhoneNumber { get; set; }

        [property: JsonPropertyName("mobilePhoneNumber")]
        public string? MobilePhoneNumber { get; set; }

        [property: JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; set; }

        public CreateCustomerRequest(string email)
        {
            Email = email;
        }
    }
}
