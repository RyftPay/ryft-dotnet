using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class CustomerDetailsRequest
    {
        [property: JsonPropertyName("id")]
        public string? Id { get; set; }

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
    }
}
