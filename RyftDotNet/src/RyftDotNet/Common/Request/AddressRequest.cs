using System.Text.Json.Serialization;

namespace RyftDotNet.Common.Request
{
    public sealed class AddressRequest
    {
        [property: JsonPropertyName("country")]
        public string Country { get; }

        [property: JsonPropertyName("postalCode")]
        public string PostalCode { get; }

        [property: JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [property: JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [property: JsonPropertyName("lineOne")]
        public string? LineOne { get; set; }

        [property: JsonPropertyName("lineTwo")]
        public string? LineTwo { get; set; }

        [property: JsonPropertyName("city")]
        public string? City { get; set; }

        [property: JsonPropertyName("region")]
        public string? Region { get; set; }

        public AddressRequest(
            string country,
            string postalCode)
        {
            Country = country;
            PostalCode = postalCode;
        }
    }
}
